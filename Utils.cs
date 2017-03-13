﻿using System.Collections.Generic;
using System.Linq;
using Planetbase;
using UnityEngine;

namespace CommunityUtils
{ }

namespace CUtils
{
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
	}

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
		public static void removeComponentFromModule<CompT, ModuleT>()
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

	public abstract class Mods
	{
		/// <summary>
		/// Add a mod's activation to the log in a standardized format. Requires that you implement ICUMod instead of IMod, as version numbers must be present.
		/// Simplest call format is to add <code>CUtils.Mods.sayActivated(this);</code> to your <see cref="IMod.Init"/>.	
		/// </summary>
		/// <param name="mod"></param>
		public static void sayActivated(ICUMod mod) {
			Debug.Log($"[MOD] {mod.GetType().Namespace} v{mod.versionMajor}.{mod.versionMinor}.{mod.versionRevision}{mod.versionAddtional} activated.");
		}
	}
}