Imports System.ComponentModel
Imports System.DirectoryServices
Imports System.Drawing.Imaging
Imports System.IO
Imports System.IO.Compression
Imports System.Net.WebRequestMethods
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports System.Text.Json
Imports BG3_Modding_Tools
Imports BG3_Modding_Tools.FuncionesHelpers
Imports LSLib.LS
Imports LSLib.LS.Enums
Imports Pfim


Class FuncionesHelpers
    'Public Shared Lista_Enum_GameObjectType As List(Of String) = [Enum].GetNames(GetType(BG3_Enum_GameObject_Type)).ToList
    Public Shared ConfigDataID As String = "bd316367-1964-4e17-b849-cde8f33d9f6e"
    Public Shared GameEngine As New Main_GameEngine_Class
    Public Shared Progreso As New BG3_Custom_Progreso_Class
    Public Shared Jsonoptions As New JsonSerializerOptions With {.IgnoreReadOnlyProperties = True, .IgnoreReadOnlyFields = True, .WriteIndented = True, .DefaultIgnoreCondition = Serialization.JsonIgnoreCondition.WhenWritingDefault}
    Public Shared Small_No_Ok As New Bitmap(My.Resources.No_Ok.ToBitmap, 16, 16)
    Public Shared Small_Ok As New Bitmap(My.Resources.Ok.ToBitmap, 16, 16)
    Public Shared Slots_Armor As New List(Of String) From {"Breast", "Amulet", "VanityBody", "Boots", "VanityBoots", "Gloves", "Cloak", "Helmet", "Ring", "Shield (Melee Offhand Weapon)", "Underwear"} ' Shield is forced in the control
    Public Shared Slots_Weapons As New List(Of String) From {"Melee Main Weapon", "Melee Offhand Weapon", "Ranged Main Weapon", "Ranged Offhand Weapon"}
    Public Shared Slots_Others As New List(Of String) From {"Wings", "Horns", "Overhead", "MusicalInstrument"}
    Public Shared ProficiencyGroup_Armor As New List(Of String) From {"None", "LightArmor", "MediumArmor", "HeavyArmor", "MusicalInstrument"}
    Public Shared ProficiencyGroup_Weapons As New List(Of String) From {"None", "Battleaxes", "Clubs", "Daggers", "Darts", "Flails", "Glaives", "Greataxes", "Greatclubs", "Greatswords", "Halberds", "HandCrossbows", "Handaxes", "HeavyCrossbows", "Javelins", "LightCrossbows", "LightHammers", "Longbows", "Longswords", "Maces", "MartialWeapons", "Mauls", "Morningstars", "Pikes", "Quarterstaffs", "Rapiers", "Scimitars", "Shields", "Shortbows", "Shortswords", "Sickles", "SimpleWeapons", "Slings", "Spears", "Tridents", "Warhammers", "Warpicks"}
    Public Shared ProficiencyGroup_Others As New List(Of String) From {"None", "MusicalInstrument"}

    Public Shared ColorMaterialsNames As New List(Of String) From {"Color_01", "Color_02", "Color_03", "Cloth_Primary", "Cloth_Secondary", "Cloth_Tertiary", "Leather_Primary", "Leather_Secondary", "Leather_Tertiary", "Metal_Primary", "Metal_Secondary", "Metal_Tertiary", "Custom_1", "Custom_2", "Accent_Color"}
    Public Shared ColorMaterialsNames2 As New List(Of String) From {"Color1", "Color2", "Color3", "Color4", "Color5"}

    ' Lists from ValueList.txt
    Public Shared Ability As New List(Of String) From {"None", "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma"}
    Public Shared Act As New List(Of String) From {"1"}
    Public Shared Action_Type As New List(Of String) From {"Regular", "Bonus"}
    Public Shared AIFlags As New List(Of String) From {"CanNotUse", "IgnoreSelf", "IgnoreDebuff", "IgnoreBuff", "StatusIsSecondary", "IgnoreControl", "CanNotTargetFrozen", "GrantsResources", "UseAsSupportingActionOnly", "UseAsSeekActionOnly"}
    Public Shared AlchemyCombinationType As New List(Of String) From {"None", "IngredientsToExtract", "ExtractToSolution"}
    Public Shared ArmorType As New List(Of String) From {"None", "Cloth", "Padded", "Leather", "StuddedLeather", "Hide", "ChainShirt", "ScaleMail", "BreastPlate", "HalfPlate", "RingMail", "ChainMail", "Splint", "Plate"}
    Public Shared AtmosphereType As New List(Of String) From {"None", "Rain", "Storm"}
    Public Shared AttributeFlags As New List(Of String) From {"None", "SlippingImmunity", "Torch", "Arrow", "Unbreakable", "Unrepairable", "Unstorable", "Grounded", "Floating", "InventoryBound", "IgnoreClouds", "LootableWhenEquipped", "PickpocketableWhenEquipped", "LoseDurabilityOnCharacterHit", "ThrownImmunity", "InvisibilityImmunity", "InvulnerableAndInteractive", "Backstab", "BackstabImmunity", "EnableObscurityEvents", "ObscurityWithoutSneaking", "FloatingWhileMoving", "ForceMainhandAlternativeEquipBones", "UseMusicalInstrumentForCasting", "ReallyArmor"}
    Public Shared AuraFlags As New List(Of String) From {"None", "CanAffectInvisibleItems", "AIIgnoreOnSelf", "ShouldCheckLOS"}
    Public Shared BigQualifier As New List(Of String) From {"None", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100"}
    Public Shared CastCheckType As New List(Of String) From {"None", "Distance", "DamageType", "TargetSurfaceType"}
    Public Shared CinematicArenaFlags As New List(Of String) From {"None", "Ignore", "AlwaysShow"}
    Public Shared CooldownType As New List(Of String) From {"None", "OncePerTurn", "OncePerCombat", "OncePerRest", "OncePerTurnNoRealtime", "OncePerShortRest", "OncePerRestPerItem", "OncePerShortRestPerItem"}
    Public Shared CursorMode As New List(Of String) From {"None", "System", "Arrow", "Arrow_Warning", "Bow", "Bow_Warning", "Bow_Ground", "Wand", "Wand_Warning", "Wand_Ground", "BackStab", "BackStab_Warning", "Cast", "Cast_Warning", "Combine", "Combine_Warning", "Combine_Invalid", "Cross", "Identify", "Identify_Warning", "ItemMove", "ItemMove_Warning", "ItemUse", "ItemUse_Warning", "ItemPickup", "ItemPickup_Warning", "Lock", "Lock_Warning", "Melee", "Melee_Warning", "Melee_Ground", "OpenContainer", "OpenContainer_Warning", "OpenContainer_New", "OpenDoor", "OpenDoor_Warning", "PickPocket", "PickPocket_Warning", "Repair", "Repair_Warning", "Shovel", "Shovel_Warning", "Talk", "Talk_Warning", "Walk", "Walk_Warning", "CameraRotation", "Listen", "Listen_Warning"}
    Public Shared Custom_Properties As New List(Of String) From {"None", "AlwaysBackstab", "Unbreakable", "CanBackstab", "AlwaysHighGround"}
    Public Shared Damage_Type As New List(Of String) From {"None", "Slashing", "Piercing", "Bludgeoning", "Acid", "Thunder", "Necrotic", "Fire", "Lightning", "Cold", "Psychic", "Poison", "Radiant", "Force"}
    Public Shared DamageSourceType As New List(Of String) From {"BaseLevelDamage", "AverageLevelDamge", "MonsterWeaponDamage", "SourceMaximumVitality", "SourceMaximumPhysicalArmor", "SourceMaximumMagicArmor", "SourceCurrentVitality", "SourceCurrentPhysicalArmor", "SourceCurrentMagicArmor", "SourceShieldPhysicalArmor", "TargetMaximumVitality", "TargetMaximumPhysicalArmor", "TargetMaximumMagicArmor", "TargetCurrentVitality", "TargetCurrentPhysicalArmor", "TargetCurrentMagicArmor", "TargetCurrentMagicArmor"}
    Public Shared Death_Type As New List(Of String) From {"None", "Acid", "Chasm", "DoT", "Electrocution", "Explode", "Falling", "Incinerate", "KnockedDown", "Lifetime", "Necrotic", "Physical", "Psychic", "Radiant", "CinematicDeath", "Cold", "Disintegrate"}
    Public Shared DieType As New List(Of String) From {"None", "d4", "d6", "d8", "d10", "d12", "d20", "d100"}
    Public Shared DisturbanceDialogueCapability As New List(Of String) From {"Excl_CanTalk", "Incl_Summon", "Incl_Wildshape", "Incl_OtherCannotTalk"}
    Public Shared DisturbanceInvestigationKind As New List(Of String) From {"InvestigateInterrogate", "None", "InvestigateOnly", "InvestigateSceneReact", "ForceInvestigateInterrogate", "ForceSceneReact", "ForceInvestigateSceneReact", "InvestigateSuspectReact", "ForceInvestigateSuspectReact", "InvestigateCriminalReact", "ForceInvestigateCriminalReact"}
    Public Shared DisturbanceMergeConditions As New List(Of String) From {"SameNonNullVictimOrCommonEvidence", "SameVictimAndCommonEvidence", "SameVictim", "Never"}
    Public Shared DisturbanceYesNoIgnoreStats As New List(Of String) From {"No", "Yes", "YesIgnoreStats"}
    Public Shared FlagType As New List(Of String) From {"Invalid", "Local", "User", "Party", "Character", "Global", "Dialog"}
    Public Shared FormatStringColor As New List(Of String) From {"White", "DarkGray", "Gray", "LightGray", "Red", "Blue", "DarkBlue", "LightBlue", "Green", "PoisonGreen", "Yellow", "Orange", "Pink", "Purple", "Brown", "Gold", "Black", "Normal", "StoryItem", "Blackrock", "Poison", "Earth", "Air", "Water", "Fire", "Source", "Decay", "Polymorph", "Ranger", "Rogue", "Summoner", "Void", "Warrior", "Special", "Healing", "Charm"}
    Public Shared Game_Action As New List(Of String) From {"None", "Douse", "CreateSurface", "TargetCreateSurface", "CreateConeSurface", "Pickup", "SwapPlaces", "Equalize"}
    Public Shared Handedness As New List(Of String) From {"Any", "1", "2"}
    Public Shared HealValueType As New List(Of String) From {"FixedValue", "Percentage", "Qualifier", "Shield", "TargetDependent", "DamagePercentage"}
    Public Shared HitAnimationType As New List(Of String) From {"Default", "PhysicalDamage", "MagicalDamage_Electric", "MagicalDamage_External", "MagicalDamage_Internal", "MagicalDamage_Psychic", "MagicalNonDamage", "None", "AnimationSetOverride"}
    Public Shared IngredientCombineType As New List(Of String) From {"None", "Base", "Additive"}
    Public Shared IngredientTransformType As New List(Of String) From {"None", "Consume", "Transform", "Poison", "Dye"}
    Public Shared IngredientType As New List(Of String) From {"None", "Object", "Category", "Property"}
    Public Shared InstrumentType As New List(Of String) From {"None", "Bagpipes", "Drum", "Dulcimer", "Flute", "Lute", "Lyre", "Horn", "Shawm", "Violin", "Musicbox", "Saxophone"}
    Public Shared InterruptContext As New List(Of String) From {"None", "OnSpellCast", "OnPostRoll", "OnCastHit", "OnEnterAttackRange", "OnLeaveAttackRange", "OnPreDamage", "OnStatusApplied", "OnDeath"}
    Public Shared InterruptContextScope As New List(Of String) From {"None", "Self", "Nearby"}
    Public Shared InterruptDefaultValue As New List(Of String) From {"None", "Ask", "Enabled"}
    Public Shared InterruptFlagsList As New List(Of String) From {"None", "InterruptWhileInvisible"}
    Public Shared InventoryTabs As New List(Of String) From {"Auto", "BooksAndKeys", "Consumable", "Equipment", "Hidden", "Ingredient", "Magical", "Misc"}
    Public Shared Itemslot As New List(Of String) From {"Helmet", "Breast", "Cloak", "Melee Main Weapon", "Melee Offhand Weapon", "Ranged Main Weapon", "Ranged Offhand Weapon", "Ring", "Underwear", "Boots", "Gloves", "Amulet", "Ring2", "Wings", "Horns", "Overhead", "MusicalInstrument", "VanityBody", "VanityBoots"}
    Public Shared ItemUseTypes As New List(Of String) From {"None", "Common", "Grenade", "Arrow", "Scroll", "Potion", "Throwable", "Consumable"}
    Public Shared LEDEffectType As New List(Of String) From {"NONE", "Loading", "LoadingProgress", "SpellPrepare", "SpellCast", "LevelUp", "QuestCompleted", "Dialog", "Spotted", "Death", "Critical", "EnemyKilled", "SaveSuccess", "SaveFailed", "StealthMode", "Crafting", "OFF", "KnockedDown", "Stunned", "Petrified", "Frozen", "Terrified", "Possessed", "Charmed", "Drunk"}
    Public Shared LineOfSightFlags As New List(Of String) From {"None", "AddSourceHeight"}
    Public Shared ManagedStatusEffectType As New List(Of String) From {"Positive", "Negative"}
    Public Shared MaterialType As New List(Of String) From {"None", "Overlay", "FadingOverlay", "Replacement"}
    Public Shared ModifierType As New List(Of String) From {"Item", "Charm", "Boost", "Skill", "Crystal", "Food"}
    Public Shared ObjectSize As New List(Of String) From {"Tiny", "Small", "Medium", "Large", "Huge", "Gargantuan"}
    Public Shared Osiris_Task As New List(Of String) From {"None", "Resurrect"}
    Public Shared PassiveFlags As New List(Of String) From {"None", "OncePerTurn", "ExecuteOnce", "IsHidden", "IsToggled", "ToggledDefaultOn", "ToggledDefaultAddToHotbar", "OncePerCombat", "OncePerShortRest", "OncePerLongRest", "MetaMagic", "OncePerAttack", "Highlighted", "Temporary", "OncePerShortRestPerItem", "OncePerLongRestPerItem", "ToggleForParty", "ForceShowInCC", "DisplayBoostInTooltip"}
    Public Shared Penalty_PreciseQualifier As New List(Of String) From {"None", "-10", "-9.9", "-9.8", "-9.7", "-9.6", "-9.5", "-9.4", "-9.3", "-9.2", "-9.1", "-9", "-8.9", "-8.8", "-8.7", "-8.6", "-8.5", "-8.4", "-8.3", "-8.2", "-8.1", "-8", "-7.9", "-7.8", "-7.7", "-7.6", "-7.5", "-7.4", "-7.3", "-7.2", "-7.1", "-7", "-6.9", "-6.8", "-6.7", "-6.6", "-6.5", "-6.4", "-6.3", "-6.2", "-6.1", "-6", "-5.9", "-5.8", "-5.7", "-5.6", "-5.5", "-5.4", "-5.3", "-5.2", "-5.1", "-5", "-4.9", "-4.8", "-4.7", "-4.6", "-4.5", "-4.4", "-4.3", "-4.2", "-4.1", "-4", "-3.9", "-3.8", "-3.7", "-3.6", "-3.5", "-3.4", "-3.3", "-3.2", "-3.1", "-3", "-2.9", "-2.8", "-2.7", "-2.6", "-2.5", "-2.4", "-2.3", "-2.2", "-2.1", "-2", "-1.9", "-1.8", "-1.7", "-1.6", "-1.5", "-1.4", "-1.3", "-1.2", "-1.1", "-1", "-0.9", "-0.8", "-0.7", "-0.6", "-0.5", "-0.4", "-0.3", "-0.2", "-0.1", "0", "0.1", "0.2", "0.3", "0.4", "0.5", "0.6", "0.7", "0.8", "0.9", "1", "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8", "1.9", "2", "2.1", "2.2", "2.3", "2.4", "2.5", "2.6", "2.7", "2.8", "2.9", "3", "3.1", "3.2", "3.3", "3.4", "3.5", "3.6", "3.7", "3.8", "3.9", "4", "4.1", "4.2", "4.3", "4.4", "4.5", "4.6", "4.7", "4.8", "4.9", "5", "5.1", "5.2", "5.3", "5.4", "5.5", "5.6", "5.7", "5.8", "5.9", "6", "6.1", "6.2", "6.3", "6.4", "6.5", "6.6", "6.7", "6.8", "6.9", "7", "7.1", "7.2", "7.3", "7.4", "7.5", "7.6", "7.7", "7.8", "7.9", "8", "8.1", "8.2", "8.3", "8.4", "8.5", "8.6", "8.7", "8.8", "8.9", "9", "9.1", "9.2", "9.3", "9.4", "9.5", "9.6", "9.7", "9.8", "9.9", "10"}
    Public Shared Penalty_Qualifier As New List(Of String) From {"None", "-10", "-9", "-8", "-7", "-6", "-5", "-4", "-3", "-2", "-1", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "100"}
    Public Shared PickingState As New List(Of String) From {"Default", "Lying", "Sitting", "Dead", "MAX", "Sneaking", "Tombstone"}
    Public Shared PreciseQualifier As New List(Of String) From {"None", "0", "0.1", "0.2", "0.3", "0.4", "0.5", "0.6", "0.7", "0.8", "0.9", "1", "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8", "1.9", "2", "2.1", "2.2", "2.3", "2.4", "2.5", "2.6", "2.7", "2.8", "2.9", "3", "3.1", "3.2", "3.3", "3.4", "3.5", "3.6", "3.7", "3.8", "3.9", "4", "4.1", "4.2", "4.3", "4.4", "4.5", "4.6", "4.7", "4.8", "4.9", "5", "5.1", "5.2", "5.3", "5.4", "5.5", "5.6", "5.7", "5.8", "5.9", "6", "6.1", "6.2", "6.3", "6.4", "6.5", "6.6", "6.7", "6.8", "6.9", "7", "7.1", "7.2", "7.3", "7.4", "7.5", "7.6", "7.7", "7.8", "7.9", "8", "8.1", "8.2", "8.3", "8.4", "8.5", "8.6", "8.7", "8.8", "8.9", "9", "9.1", "9.2", "9.3", "9.4", "9.5", "9.6", "9.7", "9.8", "9.9", "10"}
    Public Shared ProficiencyGroupFlags As New List(Of String) From {"None", "Battleaxes", "Clubs", "Daggers", "Darts", "Flails", "Glaives", "Greataxes", "Greatclubs", "Greatswords", "Halberds", "HandCrossbows", "Handaxes", "HeavyArmor", "HeavyCrossbows", "Javelins", "LightArmor", "LightCrossbows", "LightHammers", "Longbows", "Longswords", "Maces", "MartialWeapons", "Mauls", "MediumArmor", "Morningstars", "Pikes", "Quarterstaffs", "Rapiers", "Scimitars", "Shields", "Shortbows", "Shortswords", "Sickles", "SimpleWeapons", "Slings", "Spears", "Tridents", "Warhammers", "Warpicks", "MusicalInstrument"}
    Public Shared Progression_Type As New List(Of String) From {"Level", "ChallengeRating"}
    Public Shared ProjectileDistribution As New List(Of String) From {"Random", "Normal", "Edge", "EdgeCenter"}
    Public Shared ProjectileType As New List(Of String) From {"None", "Arrow", "Grenade"}
    Public Shared Qualifier As New List(Of String) From {"None", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"}
    Public Shared Rarity As New List(Of String) From {"Common", "Uncommon", "Rare", "VeryRare", "Legendary"}
    Public Shared Relation As New List(Of String) From {"Ally", "Neutral", "Enemy", "Persistent Neutral"}
    Public Shared ResistanceFlags As New List(Of String) From {"None", "Resistant", "Immune", "Vulnerable", "ResistantToMagical", "ImmuneToMagical", "VulnerableToMagical", "ResistantToNonMagical", "ImmuneToNonMagical", "VulnerableToNonMagical"}
    Public Shared RestErrorFlags As New List(Of String) From {"None", "GlobalDisabled", "Script", "Dialog", "Combat", "FTB", "NotEnoughResources", "DownedOrDead"}
    Public Shared Skill As New List(Of String) From {"None", "WarriorLore", "RangerLore", "RogueLore", "SingleHanded", "TwoHanded", "Investigation", "Ranged", "Shield", "Perception", "PhysicalArmorMastery", "Arcana", "Insight", "FireSpecialist", "WaterSpecialist", "AirSpecialist", "Survival", "Religion", "AnimalHandling", "Polymorph", "Repair", "Stealth", "SleightOfHand", "Thievery", "History", "Crafting", "Performance", "Deception", "Intimidation", "Reason", "Persuasion", "Leadership", "Luck", "DualWielding", "Wand", "MagicArmorMastery", "Medicine", "Perseverance", "Runecrafting", "Brewmaster", "Athletics", "Acrobatics", "Sulfurology"}
    Public Shared SoundVocalType As New List(Of String) From {"NONE", "ATTACK", "DEATH", "DODGE", "PAIN", "ANTICIPATION", "FALL", "SHOUT", "SPAWN", "ALERT", "ANGRY", "AWAKE", "BORED", "VICTORY", "REBORN", "RELAXED", "SNORE", "EXHAUSTED", "EFFORTS", "INITIATIVE", "WEAK", "LAUGHTER", "RECOVER", "BUFF", "IDLE1", "IDLE2", "IDLE3", "IDLECOMBAT1", "IDLECOMBAT2", "IDLECOMBAT3", "GASP", "LAUGHTERMANIACAL", "MAX"}
    Public Shared Spell_Attack_Type As New List(Of String) From {"DirectHit", "MeleeWeaponAttack", "RangedWeaponAttack", "MeleeSpellAttack", "RangedSpellAttack"}
    Public Shared SpellActionType As New List(Of String) From {"None", "Dash", "Dip", "Disengage", "Distract", "Help", "Hide", "Jump", "Knockout", "Shove", "Throw", "Dismiss", "ImprovisedWeapon"}
    Public Shared SpellAnimationIntentType As New List(Of String) From {"None", "Aggressive", "Peaceful", "Action"}
    Public Shared SpellAnimationType As New List(Of String) From {"None", "Dipping", "Assisting", "Throwing", "ImprovisedWeapon", "Restrain", "Shoving", "Jumping", "Telekinesis"}
    Public Shared SpellCategoryFlags As New List(Of String) From {"SC_None", "SC_TargetSingle", "SC_TargetMultiselect", "SC_TargetAoE", "SC_IntentDamage", "SC_IntentHealing", "SC_IntentBuff", "SC_IntentDebuff", "SC_IntentUtility", "SC_Jump", "SC_Dash", "SC_DetectThoughts"}
    Public Shared SpellElement As New List(Of String) From {"None"}
    Public Shared SpellFlagList As New List(Of String) From {"None", "HasVerbalComponent", "HasSomaticComponent", "IsJump", "IsAttack", "IsMelee", "HasHighGroundRangeExtension", "IsConcentration", "AddFallDamageOnLand", "ConcentrationIgnoresResting", "InventorySelection", "IsSpell", "CombatLogSetSingleLineRoll", "IsEnemySpell", "CannotTargetCharacter", "CannotTargetItems", "CannotTargetTerrain", "IgnoreVisionBlock", "Stealth", "AddWeaponRange", "IgnoreSilence", "ImmediateCast", "RangeIgnoreSourceBounds", "RangeIgnoreTargetBounds", "RangeIgnoreVerticalThreshold", "NoSurprise", "IsHarmful", "IsTrap", "IsDefaultWeaponAction", "CallAlliesSpell", "TargetClosestEqualGroundSurface", "CannotRotate", "NoCameraMove", "CanDualWield", "IsLinkedSpellContainer", "Invisible", "AllowMoveAndCast", "UNUSED_D", "Wildshape", "UNUSED_E", "UnavailableInDialogs", "TrajectoryRules", "PickupEntityAndMove", "Temporary", "RangeIgnoreBlindness", "AbortOnSpellRollFail", "AbortOnSecondarySpellRollFail", "CanAreaDamageEvade", "DontAbortPerforming", "NoCooldownOnMiss", "NoAOEDamageOnLand", "IsSwarmAttack", "DisplayInItemTooltip", "HideInItemTooltip", "DisableBlood", "IgnorePreviouslyPickedEntities", "IgnoreAoO", "DisplayDamageModifiers", "ChasmRecovery"}
    Public Shared SpellJumpType As New List(Of String) From {"None", "Jump", "Pounce", "Flight"}
    Public Shared SpellRequirement As New List(Of String) From {"None", "MeleeWeapon", "RangedWeapon", "StaffWeapon", "DaggerWeapon", "ShieldWeapon", "RifleWeapon", "ArrowWeapon"}
    Public Shared SpellSchool As New List(Of String) From {"None", "Abjuration", "Conjuration", "Divination", "Enchantment", "Evocation", "Illusion", "Necromancy", "Transmutation"}
    Public Shared SpellSheathing As New List(Of String) From {"Somatic", "DontChange", "Instrument", "Melee", "Ranged", "Sheathed", "WeaponSet"}
    Public Shared SpellSoundMagnitude As New List(Of String) From {"Normal", "None", "Small", "Big"}
    Public Shared SpellStyleGroup As New List(Of String) From {"Intent", "Class", "Class_Intent"}
    Public Shared StatsFunctorContext As New List(Of String) From {"None", "Target", "AOE", "OnCast", "OnEquip", "Ground", "OnLeaveAttackRange", "OnEntityAttackedWithinMeleeRange", "OnEntityAttackingWithinMeleeRange", "OnProficiencyChange", "OnStatusApply", "OnStatusApplied", "OnStatusRemove", "OnMovedDistance", "AiOnly", "AiIgnore", "OnAttack", "OnAttacked", "OnDamage", "OnHeal", "OnStatusRemoved", "OnObscurityChanged", "OnShortRest", "OnDamaged", "OnHealed", "OnAbilityCheck", "OnCastResolved", "OnLongRest", "OnCreate", "OnPush", "OnPushed", "OnInventoryChanged", "OnEnterAttackRange", "OnProjectileExploded", "OnCombatEnded", "OnTurn", "OnActionResourcesChanged", "OnSurfaceEnter", "OnLockpickingSucceeded", "OnInterruptUsed", "OnDamagePrevented", "OnDamagedPrevented", "OnRound", "OnCombatStarted"}
    Public Shared StatusAnimationType As New List(Of String) From {"None", "Feared", "KO", "KO_Fallen", "Sleeping", "Blinded", "Snared", "Dazed", "Downed", "Weakened", "Climbing", "Mental", "Sneaking", "Shouting", "Sitting", "LongRest", "Laughing", "Swapped", "Grappled", "Grappling", "Performing1", "Performing2", "Performing3", "PerformingFail", "Dancing", "Suffocating", "Laughing_Hideous", "Frightened", "Petrified", "Channeling", "Performing4", "Performing5", "Performing6", "Performing7", "Performing8", "Performing9", "Performing10"}
    Public Shared StatusEvent As New List(Of String) From {"None", "OnTurn", "OnSpellCast", "OnAttack", "OnAttacked", "OnApply", "OnRemove", "OnApplyAndTurn", "OnDamage", "OnEquip", "OnUnequip", "OnHeal", "OnObscurityChanged", "UNUSED1", "OnSurfaceEnter", "OnStatusApplied", "OnStatusRemoved", "OnMove", "OnCombatEnded", "OnRemovePerformanceRequest", "OnLockpickingSucceeded", "OnSourceDeath", "OnSourceStatusApplied", "OnFactionChanged", "OnEntityPickUp", "OnEntityDrop", "OnEntityDrag", "OnLockpickingFinished", "OnDisarmingFinished"}
    Public Shared StatusGroupFlags As New List(Of String) From {"SG_None", "SG_Condition", "SG_Blinded", "SG_Charmed", "SG_Cursed", "SG_Disease", "SG_Exhausted", "SG_Frightened", "SG_Incapacitated", "SG_Invisible", "SG_Poisoned", "SG_Prone", "SG_Restrained", "SG_Stunned", "SG_Unconscious", "SG_Surface", "SG_Polymorph", "SG_Paralyzed", "SG_Light", "SG_Disguise", "SG_Possessed", "SG_Petrified", "SG_Polymorph_BeastShape", "SG_Polymorph_BeastShape_NPC", "SG_Poisoned_Story_Removable", "SG_Poisoned_Story_Nonremovable", "SG_Charmed_Subtle", "SG_Helpable_Condition", "SG_Rage", "SG_Taunted", "SG_Approaching", "SG_Dominated", "SG_Fleeing", "SG_Confused", "SG_Mad", "SG_DetectThoughts", "SG_DifficultTerrain", "SG_ScriptedPeaceBehaviour", "SG_DropForNonMutingDialog", "SG_HexbladeCurse", "SG_WeaponCoating", "SG_Doppelganger", "SG_CanBePickedUp", "SG_Drunk", "SG_Sleeping", "SG_RemoveOnRespec", "SG_Ignore_AOO", "SG_Sleeping_Magical"}
    Public Shared StatusHealType As New List(Of String) From {"None", "Vitality", "PhysicalArmor", "MagicArmor", "AllArmor", "All", "Source"}
    Public Shared StatusPropertyFlags As New List(Of String) From {"None", "Performing", "InitiateCombat", "BringIntoCombat", "ForceOverhead", "IsChanneled", "IsInvulnerable", "ExcludeFromPortraitRendering", "LoseControl", "ForceNeutralInteractions", "PeaceOnly", "AllowLeaveCombat", "DisableImmunityOverhead", "DisableInteractions", "Toggle", "IgnoreResting", "IgnoredByImmobilized", "Blind", "MultiplyEffectsByDuration", "TickingWithSource", "DisableOverhead", "DisableCombatlog", "DisablePortraitIndicator", "ExecuteFunctorsOnOwner", "IsInvulnerableVisible", "ApplyToDead", "GiveExp", "Burning", "NonExtendable", "FreezeDuration", "UnavailableInActiveRoll", "OverheadOnTurn", "UnsheathInstrument", "IndicateDarkness", "LoseControlFriendly", "DisableCapabilitiesMessage", "AllowLeaveDisallowJoinCombat", "RemoveOnLongRest"}
    Public Shared StatusSheathing As New List(Of String) From {"None", "Instrument", "Melee", "Ranged", "Sheathed"}
    Public Shared StatusStackType As New List(Of String) From {"Stack", "Ignore", "Overwrite", "Deactivate", "Variable", "Additive"}
    Public Shared StepsType As New List(Of String) From {"Bare", "Bone", "Spider", "Leather", "Metal", "Hooves", "Clawed"}
    Public Shared StillAnimPriority As New List(Of String) From {"Suffocating", "Weakened", "Dazed", "Blinded", "Frightened", "Feared", "Mental", "Sneaking", "Sitting", "Dance", "Snared", "Performing", "Shouting", "Laughing", "Sleeping", "KO_Fallen", "KO", "Downed"}
    Public Shared Surface_Change As New List(Of String) From {"None", "Ignite", "Douse", "Electrify", "Deelectrify", "Freeze", "Melt", "Vaporize", "Condense", "DestroyWater", "Clear", "Daylight", "TurnHellfire", "UnturnHellfire"}
    Public Shared Surface_Type As New List(Of String) From {"None", "Water", "WaterElectrified", "WaterFrozen", "Blood", "BloodElectrified", "BloodFrozen", "Poison", "Oil", "Lava", "Grease", "WyvernPoison", "Web", "Deepwater", "Vines", "Fire", "Acid", "TrialFire", "Blackpowder", "ShadowCursedVines", "Alienoil", "Mud", "Alcohol", "InvisibleWeb", "BloodSilver", "Chasm", "Hellfire", "CausticBrine", "BloodExploding", "Ash", "SpikeGrowth", "HolyFire", "BlackTentacles", "Overgrowth", "PurpleWormPoison", "SerpentVenom", "InvisibleGithAcid", "BladeBarrier", "Sewer", "WaterCloud", "WaterCloudElectrified", "PoisonCloud", "ExplosionCloud", "ShockwaveCloud", "CloudkillCloud", "MaliceCloud", "BloodCloud", "StinkingCloud", "DarknessCloud", "FogCloud", "GithPheromoneGasCloud", "SporeWhiteCloud", "SporeGreenCloud", "SporeBlackCloud", "DrowPoisonCloud", "IceCloud", "PotionHealingCloud", "PotionHealingGreaterCloud", "PotionHealingSuperiorCloud", "PotionHealingSupremeCloud", "PotionInvisibilityCloud", "PotionSpeedCloud", "PotionVitalityCloud", "PotionAntitoxinCloud", "PotionResistanceAcidCloud", "PotionResistanceColdCloud", "PotionResistanceFireCloud", "PotionResistanceForceCloud", "PotionResistanceLightningCloud", "PotionResistancePoisonCloud", "SporePinkCloud", "BlackPowderDetonationCloud", "VoidCloud", "CrawlerMucusCloud", "Cloudkill6Cloud", "Sentinel"}
    Public Shared TagCategory As New List(Of String) From {"None", "Code", "Dialog", "Gender", "Origin", "Profession", "Race", "Story", "Voice"}
    Public Shared Tension As New List(Of String) From {"any", "low", "high"}
    Public Shared ThrowOrigin As New List(Of String) From {"Caster", "Target"}
    Public Shared TickType As New List(Of String) From {"StartTurn", "EndTurn", "StartRound", "EndRound"}
    Public Shared VerbalIntent As New List(Of String) From {"None", "Damage", "Healing", "Buff", "Debuff", "Utility", "Control", "Summon"}
    Public Shared Weapon_Group As New List(Of String) From {"SimpleMeleeWeapon", "SimpleRangedWeapon", "MartialMeleeWeapon", "MartialRangedWeapon"}
    Public Shared WeaponFlags As New List(Of String) From {"None", "Light", "Ammunition", "Finesse", "Heavy", "Loading", "Range", "Reach", "Lance", "Net", "Thrown", "Twohanded", "Versatile", "Melee", "Dippable", "Torch", "NoDualWield", "Magical", "NeedDualWieldingBoost", "NotSheathable", "Unstowable", "AddToHotbar"}
    Public Shared WeaponSet As New List(Of String) From {"Melee", "Ranged"}
    Public Shared YesNo As New List(Of String) From {"No", "Yes"}
    Public Shared Visual_Slots As New List(Of String) From {"Unassigned", "Body", "Footwear", "Cloak", "Gloves", "Underwear", "DragonbornTop", "Head", "Headwear", "Horns", "HelmetHair", "Hair", "DragonbornChin", "Hair DWR", "NakedBody", "Private Parts", "DragonbornJaw", "Piercing", "ModestyLeaf", "Beard", "Test", ""}
    Public Shared VertexColorMaskSlots As New List(Of String) From {"Torso", "Shoulders", "upperarm", "lowerarm", "wrists", "hands", "Thighs", "knees", "shins", "feet", "decolletage_01", "decolletage_02", "Underwear_Bra", "Underwear_Panties", "Underwear_Panties_Tail", "Private_Parts", "ModestyLeaf", "Nipple Covers", "Sleeves", "Pants", "Never Hide Hair", "(Hot Pink Physics Paint)", "(Red Physics Paint)"}
    Public Shared ReplenishType As New List(Of String) From {"Never", "Turn", "Rest", "ShortRest", "FullRest"}
End Class
Module Flickering
    Public Sub EnableDoubleBuffering(ByVal control As Control)
        SendMessage(control.Handle, TVM_SETEXTENDEDSTYLE, CType(TVS_EX_DOUBLEBUFFER, IntPtr), CType(TVS_EX_DOUBLEBUFFER, IntPtr))
    End Sub

    Private Const TVM_SETEXTENDEDSTYLE As Integer = &H1100 + 44
    'Private Const TVM_GETEXTENDEDSTYLE As Integer = &H1100 + 45
    Private Const TVS_EX_DOUBLEBUFFER As Integer = &H4
    Private Const WM_SETREDRAW As Integer = 11


    <DllImport("user32.dll")>
    Private Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wp As IntPtr, ByVal lp As IntPtr) As IntPtr
    End Function
    <DllImport("user32.dll")>
    Private Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Boolean, ByVal lParam As IntPtr) As Integer
    End Function
    Public Function ResumeDrawing(ByVal Target As Control, ByVal Redraw As Boolean) As Integer
        Dim rs = SendMessage(Target.Handle, WM_SETREDRAW, True, IntPtr.Zero)
        If Redraw Then
            Target.Refresh()
        End If
        Return rs
    End Function
    Public Function SuspendDrawing(ByVal Target As Control) As Integer
        Return SendMessage(Target.Handle, WM_SETREDRAW, False, IntPtr.Zero)
    End Function
    Public Sub ResumeDrawing(ByVal Target As Control)
        ResumeDrawing(Target, True)
    End Sub

End Module

