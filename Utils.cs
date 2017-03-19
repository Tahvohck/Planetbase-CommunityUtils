using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using Planetbase;
using UnityEngine;

namespace CommunityUtils
{
	/// <summary>
	/// Community utilities to make modding easier and the code for it read cleaner.
	/// </summary>
	public abstract class CUtils
	{
		/// <summary>
		/// Tools for working with components.
		/// </summary>
		public abstract class Components
		{
			/// <summary>
			/// Register a new component into the <see cref="Planetbase.ComponentTypeList"/> so that it can be added to modules later.
			/// </summary>
			/// <returns><see cref="System.Boolean"/>: true if sucessful, false if not. (To be implemented)</returns>
			public static void register(ComponentType newCompType) {
				TypeList<ComponentType, ComponentTypeList>.getInstance().add(newCompType);
			}

			/// <summary>
			/// Get a <see cref="ComponentType"/>.
			/// Functionally identical to TypeList&lt;<see cref="ComponentType"/>, <see cref="ComponentTypeList"/>&gt;.find&lt;T&gt;() but easier to remember.
			/// </summary>
			/// <typeparam name="T">The type of worker to get the specialization of.</typeparam>
			/// <returns></returns>
			public static ComponentType find<T>()
			where T : ComponentType {
				return TypeList<ComponentType, ComponentTypeList>.find<T>();
			}

			/// <summary>
			/// Clone all settings from CloneFromType to the passed component. THIS IS DESTRUCTIVE TO EXISTING SETTINGS.
			/// 
			/// Not cloned: mPrefabName
			/// </summary>
			/// <typeparam name="CloneFromType">The type to clone settings from</typeparam>
			/// <param name="cloneTo">Clone settings onto this instance.</param>
			public static void clone<CloneFromType>(ComponentType cloneTo)
			where CloneFromType : ComponentType, new() {
				ComponentType cloneFrom = new CloneFromType();
				cloneTo.mConditionDecayTime = cloneFrom.mConditionDecayTime;
				cloneTo.mConstructionCosts = cloneFrom.mConstructionCosts;
				cloneTo.mConsumedResource = cloneFrom.mConsumedResource;
				cloneTo.mEmbeddedResourceCount = cloneFrom.mEmbeddedResourceCount;
				cloneTo.mFlags = cloneFrom.mFlags;
				cloneTo.mHeight = cloneFrom.mHeight;
				cloneTo.mHoldResourceCount = cloneFrom.mHoldResourceCount;
				cloneTo.mIcon = cloneFrom.mIcon;
				cloneTo.mMaxUsageTime = cloneFrom.mMaxUsageTime;
				cloneTo.mMaxUsers = cloneFrom.mMaxUsers;
				cloneTo.mModel = cloneFrom.loadPrefab();
				cloneTo.mName = cloneFrom.mName;
				cloneTo.mOperatedModuleType = cloneFrom.mOperatedModuleType;
				cloneTo.mOperatorSpecialization = cloneFrom.mOperatorSpecialization;
				cloneTo.mOverrideSelectionBounds = cloneFrom.mOverrideSelectionBounds;
				cloneTo.mOxygenGeneration = cloneFrom.mOxygenGeneration;
				cloneTo.mPowerGeneration = cloneFrom.mPowerGeneration;
				cloneTo.mPrimaryStatusRecovery = cloneFrom.mPrimaryStatusRecovery;
				cloneTo.mProduction = cloneFrom.mProduction;
				cloneTo.mRadius = cloneFrom.mRadius;
				cloneTo.mRecipes = cloneFrom.mRecipes;
				cloneTo.mRepairTime = cloneFrom.mRepairTime;
				cloneTo.mRequiredTech = cloneFrom.mRequiredTech;
				cloneTo.mResourceConsumption = cloneFrom.mResourceConsumption;
				cloneTo.mResourceProductionPeriod = cloneFrom.mResourceProductionPeriod;
				cloneTo.mStatusRecoveryTimes = cloneFrom.mStatusRecoveryTimes;
				cloneTo.mStoredResources = cloneFrom.mStoredResources;
				cloneTo.mSurveyedConstructionCount = cloneFrom.mSurveyedConstructionCount;
				cloneTo.mTooltip = cloneFrom.mTooltip;
				cloneTo.mTransitionInAnimations = cloneFrom.mTransitionInAnimations;
				cloneTo.mTransitionOutAnimations = cloneFrom.mTransitionOutAnimations;
				cloneTo.mUsageAnimations = cloneFrom.mUsageAnimations;
				cloneTo.mUsageCooldown = cloneFrom.mUsageCooldown;
				cloneTo.mWallSeparation = cloneFrom.mWallSeparation;
				cloneTo.mWaterGeneration = cloneFrom.mWaterGeneration;
			}
		}

		/// <summary>
		/// Tools for working with Modules (AKA structures).
		/// </summary>
		public abstract class Modules
		{
			/// <summary>
			/// Add a <see cref="Planetbase.ComponentType"/> to a <see cref="Planetbase.ModuleType"/>'s build list at a specific postion.
			/// </summary>
			/// <typeparam name="CompT">Component type to add.</typeparam>
			/// <typeparam name="ModuleT">Module type to add to.</typeparam>
			/// <param name="position">The position in the Module list to add the new component to.</param>
			public static void addComponentAtPos<CompT, ModuleT>(byte position)
			where CompT : ComponentType where ModuleT : ModuleType {
				ModuleT module = findType<ModuleT>() as ModuleT;
				List<ComponentType> components = module.mComponentTypes.ToList();
				components.Insert(position, Components.find<CompT>());
				module.mComponentTypes = components.ToArray();
			}

			/// <summary>
			/// Add a <see cref="Planetbase.ComponentType"/> to a <see cref="Planetbase.ModuleType"/>'s build list at the end.
			/// </summary>
			/// <typeparam name="CompT">Component type to add.</typeparam>
			/// <typeparam name="ModuleT">Module type to add to.</typeparam>
			public static void addComponent<CompT, ModuleT>()
			where CompT : ComponentType where ModuleT : ModuleType {
				ModuleT module = findType<ModuleT>() as ModuleT;
				List<ComponentType> components = module.mComponentTypes.ToList();
				components.Add(Components.find<CompT>());
				module.mComponentTypes = components.ToArray();
			}

			/// <summary>
			/// Remove a <see cref="Planetbase.ComponentType"/> to a <see cref="Planetbase.ModuleType"/>'s build list.
			/// </summary>
			/// <typeparam name="CompT">Component type to add.</typeparam>
			/// <typeparam name="ModuleT">Module type to add to.</typeparam>
			public static void removeComponent<CompT, ModuleT>()
			where CompT : ComponentType where ModuleT : ModuleType {
				ModuleT module = findType<ModuleT>() as ModuleT;
				List<ComponentType> components = module.mComponentTypes.ToList();
				components.Remove(Components.find<CompT>());
				module.mComponentTypes = components.ToArray();
			}

			/// <summary>
			/// Get a <see cref="ModuleType"/>.
			/// Functionally identical to TypeList&lt;<see cref="ModuleType"/>, <see cref="ModuleTypeList"/>&gt;.find&lt;T&gt;() but easier to remember.
			/// </summary>
			/// <typeparam name="T">The type of worker to get the specialization of.</typeparam>
			/// <returns></returns>
			public static ModuleType findType<T>()
			where T : ModuleType {
				return TypeList<ModuleType, ModuleTypeList>.find<T>();
			}
		}

		/// <summary>
		/// Tools for working with Resources (Meals, Metal, Bioplastic, etc)
		/// </summary>
		public abstract class Resources
		{
			/// <summary>
			/// Get a <see cref="ResourceType"/>.
			/// Functionally identical to TypeList&lt;<see cref="ResourceType"/>, <see cref="ResourceTypeList"/>&gt;.find&lt;T&gt;() but easier to remember.
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <returns></returns>
			public static ResourceType findType<T>()
			where T : ResourceType {
				return TypeList<ResourceType, ResourceTypeList>.find<T>();
			}
		}

		/// <summary>
		/// Tools for working with Colonists/Visitors.
		/// </summary>
		public abstract class Workers
		{
			/// <summary>
			/// Get a <see cref="Specialization"/>.
			/// Functionally identical to TypeList&lt;<see cref="Specialization"/>, <see cref="SpecializationList"/>&gt;.find&lt;T&gt;() but easier to remember.
			/// </summary>
			/// <typeparam name="T">The type of worker to get the specialization of.</typeparam>
			/// <returns></returns>
			public static Specialization findType<T>()
			where T : Specialization {
				return TypeList<Specialization, SpecializationList>.find<T>();
			}
		}

		/// <summary>
		/// Tools for working with the string database.
		/// </summary>
		public abstract class Strings
		{
			/// <summary>
			/// Add tooltip to the string library for the given type. Only sanity check is to not try to add if there already exists that key.
			/// </summary>
			/// <typeparam name="T">Type to add a tooltip for.</typeparam>
			/// <param name="tooltip">Tooltip to add to the string library.</param>
			public static void addTooltipFor<T>(string tooltip) {
				if (!StringList.exists("tooltip_" + Util.camelCaseToLowercase(typeof(T).Name))) {
					StringList.mStrings.Add("tooltip_" + Util.camelCaseToLowercase(typeof(T).Name), tooltip);
				}
			}

			/// <summary>
			/// Add name to the string library for the given component. Only sanity check is to not try to add if there already exists that key.
			/// </summary>
			/// <typeparam name="T">Type to add a tooltip for.</typeparam>
			/// <param name="name">Tooltip to add to the string library.</param>
			public static void addNameForComponent<T>(string name) {
				if (!StringList.exists("component_" + Util.camelCaseToLowercase(typeof(T).Name))) {
					StringList.mStrings.Add("component_" + Util.camelCaseToLowercase(typeof(T).Name), name);
				}
			}
		}

		/// <summary>
		/// Add a mod's activation to the log in a standardized format. Requires that you implement ICUMod as well as IMod, as version numbers must be present.
		/// Simplest call format is to add <code>CUtils.Mods.sayActivated(this);</code> to your <see cref="IMod.Init"/>.	
		/// </summary>
		/// <param name="mod"></param>
		public static void sayActivated(ICUMod mod) {
			Debug.Log($"[MOD] {splitOnCaps(mod.GetType().Namespace)} v{mod.versionMajor}.{mod.versionMinor}.{mod.versionRevision}{mod.versionAddtional} activated.");
		}

		/// <summary>
		/// Split a camel case string into multiple words.
		/// </summary>
		/// <param name="str">String to split</param>
		/// <returns></returns>
		public static string splitOnCaps(string str) {
			Regex matcher = new Regex("([a-z])([A-Z][a-z])");
			return matcher.Replace(str, "$1 $2");
		}

	}
}