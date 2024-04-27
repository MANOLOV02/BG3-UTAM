﻿using System;
using System.IO;

namespace Pfim
{
    /// <summary>
    /// Class representing decoding compressed direct draw surfaces
    /// </summary>
    public abstract class CompressedDds : Dds
    {
        private bool _compressed;
        private MipMapOffset[] _mipMaps = new MipMapOffset[0];

        public override MipMapOffset[] MipMaps => _mipMaps;

        protected CompressedDds(DdsHeader header, PfimConfig config) : base(header, config)
        {
        }

        /// <summary>Decompress a given block</summary>
        protected abstract int Decode(byte[] stream, byte[] data, int streamIndex, uint dataIndex, uint stride);

        /// <summary>Number of bytes for a pixel in the decoded data</summary>
        protected abstract byte PixelDepthBytes { get; }

        /// <summary>
        /// The length of a block is in pixels. This mainly affects compressed
        /// images as they are encoded in blocks that are divSize by divSize.
        /// Uncompressed DDS do not need this value.
        /// </summary>
        protected abstract byte DivSize { get; }

        /// <summary>
        /// Number of bytes needed to decode block of pixels that is divSize
        /// by divSize.  This takes into account how many bytes it takes to
        /// extract color and alpha information. Uncompressed DDS do not need
        /// this value.
        /// </summary>
        protected abstract byte CompressedBytesPerBlock { get; }
        public override bool Compressed => _compressed;

        public override int Stride => DeflatedStrideBytes;
        private int BytesPerStride => WidthBlocks * CompressedBytesPerBlock;
        private int WidthBlocks => CalcBlocks((int) Header.Width);
        private int HeightBlocks => CalcBlocks((int) Header.Height);
        private int StridePixels => WidthBlocks * DivSize;
        private int DeflatedStrideBytes => StridePixels * PixelDepthBytes;
        private int CalcBlocks(int pixels) => Math.Max(1, (pixels + 3) / 4);

        /// <summary>Decode data into raw rgb format</summary>
        public byte[] DataDecode(Stream stream, PfimConfig config)
        {
            // If we are decoding in memory data, decode stream from that instead of
            // an intermediate buffer
            if (stream is MemoryStream s && s.TryGetBuffer(out var arr))
            {
                return InMemoryDecode(arr.Array, (int)s.Position);
            }

            DataLen = HeightBlocks * DivSize * DeflatedStrideBytes;
            var totalLen = AllocateMipMaps();
            byte[] data = Config.Allocator.Rent(totalLen);
            var pixelsLeft = totalLen;
            int dataIndex = 0;

            int imageIndex = 0;
            int divSize = DivSize;
            int stride = DeflatedStrideBytes;
            int blocksPerStride = WidthBlocks;
            int indexPixelsLeft = HeightBlocks * DivSize * stride;
            var stridePixels = StridePixels;

            int strideBlocksRemaining = blocksPerStride;
            byte[] streamBuffer = config.Allocator.Rent(config.BufferSize);
            try
            {
                int workingSize = Util.ReadFill(stream, streamBuffer, 0, config.BufferSize);
                while (workingSize > 0 && indexPixelsLeft > 0)
                {
                    int bIndex = 0;
                    int workingBlocks = workingSize / CompressedBytesPerBlock;
                    while (workingBlocks > 0)
                    {
                        bIndex = Decode(streamBuffer, data, bIndex, (uint)dataIndex, (uint)stridePixels);
                        
                        // Advance to the next block
                        dataIndex += divSize * PixelDepthBytes;

                        workingBlocks -= 1;
                        strideBlocksRemaining -= 1;
                        if (strideBlocksRemaining == 0)
                        {
                            strideBlocksRemaining = blocksPerStride;
                            indexPixelsLeft -= stride * divSize;
                            pixelsLeft -= stride * divSize;

                            // Jump down to the starting block
                            dataIndex += stride * (divSize - 1);

                            if (indexPixelsLeft <= 0)
                            {
                                if (imageIndex >= MipMaps.Length) break;

                                var mip = MipMaps[imageIndex];
                                var widthBlocks = CalcBlocks(mip.Width);
                                var heightBlocks = CalcBlocks(mip.Height);
                                stridePixels = widthBlocks * DivSize;
                                stride = stridePixels * PixelDepthBytes;
                                blocksPerStride = widthBlocks;
                                strideBlocksRemaining = blocksPerStride;
                                indexPixelsLeft = heightBlocks * DivSize * stride;
                                imageIndex++;
                            }
                        }
                    }

                    workingSize = Util.Translate(stream, streamBuffer, config.BufferSize, bIndex);
                }

                return data;
            }
            finally
            {
                config.Allocator.Return(streamBuffer);
            }
        }

        private int AllocateMipMaps()
        {
            var len = HeightBlocks * DivSize * DeflatedStrideBytes;

            if (Header.MipMapCount <= 1)
            {
                return len;
            }

            _mipMaps = new MipMapOffset[Header.MipMapCount - 1];
            var totalLen = len;

            for (int i = 1; i < Header.MipMapCount; i++)
            {
                var width = Math.Max((int)(Header.Width / Math.Pow(2, i)), 1);
                var height = Math.Max((int)(Header.Height / Math.Pow(2, i)), 1);
                var widthBlocks = CalcBlocks(width);
                var heightBlocks = CalcBlocks(height);

                var stridePixels = widthBlocks * DivSize;
                var stride = stridePixels * PixelDepthBytes;

                len = heightBlocks * DivSize * stride;
                _mipMaps[i - 1] = new MipMapOffset(width, height, stride, totalLen, len);
                totalLen += len;
            }

            return totalLen;
        }

        private byte[] InMemoryDecode(byte[] memBuffer, int bIndex)
        {
            DataLen = HeightBlocks * DivSize * DeflatedStrideBytes;
            var totalLen = AllocateMipMaps();
            byte[] data = Config.Allocator.Rent(totalLen);
            var pixelsLeft = totalLen;
            int dataIndex = 0;

            for (int imageIndex = 0; imageIndex < Header.MipMapCount + 1 && pixelsLeft > 0; imageIndex++)
            {
                int divSize = DivSize;
                int stride = DeflatedStrideBytes;
                int blocksPerStride = WidthBlocks;
                int indexPixelsLeft = HeightBlocks * DivSize * stride;
                var stridePixels = StridePixels;

                if (imageIndex != 0)
                {
                    var width = Math.Max((int)(Header.Width / Math.Pow(2, imageIndex)), 1);
                    var height = Math.Max((int)(Header.Height / Math.Pow(2, imageIndex)), 1);
                    var widthBlocks = CalcBlocks(width);
                    var heightBlocks = CalcBlocks(height);

                    stridePixels = widthBlocks * DivSize;
                    stride = stridePixels * PixelDepthBytes;
                    blocksPerStride = widthBlocks;
                    indexPixelsLeft = heightBlocks * DivSize * stride;
                }

                while (indexPixelsLeft > 0)
                {
                    var origDataIndex = dataIndex;

                    for (uint i = 0; i < blocksPerStride; i++)
                    {
                        bIndex = Decode(memBuffer, data, bIndex, (uint)dataIndex, (uint)stridePixels);
                        dataIndex += divSize * PixelDepthBytes;
                    }

                    var filled = stride * divSize;
                    pixelsLeft -= filled;
                    indexPixelsLeft -= filled;

                    // Jump down to the block that is exactly (divSize - 1)
                    // below the current row we are on
                    dataIndex = origDataIndex + filled;
                }
            }

            return data;
        }

        protected override void Decode(Stream stream, PfimConfig config)
        {
            if (config.Decompress)
            {
                Data = DataDecode(stream, config);
            }
            else
            {
                var heightBlockAligned = HeightBlocks;
                long totalSize = WidthBlocks * CompressedBytesPerBlock * heightBlockAligned;

                for (int i = 1; i < Header.MipMapCount; i++)
                {
                    var width = Math.Max((int)(Header.Width   / Math.Pow(2, i)), 1);
                    var height = Math.Max((int)(Header.Height / Math.Pow(2, i)), 1);
                    var widthBlocks = CalcBlocks(width);
                    var heightBlocks = CalcBlocks(height);
                    totalSize += widthBlocks * heightBlocks * CompressedBytesPerBlock;
                }

                DataLen = (int)totalSize;
                Data = config.Allocator.Rent((int)totalSize);
                _compressed = true;
                Util.Fill(stream, Data, DataLen, config.BufferSize);
            }
        }

        public override void Decompress()
        {
            if (!_compressed)
            {
                return;
            }

            Data = InMemoryDecode(Data, 0);
            _compressed = false;
        }
    }
}
