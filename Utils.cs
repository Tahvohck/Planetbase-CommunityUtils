using System;
using System.Collections.Generic;
using System.Linq;
using Planetbase;

namespace CommunityUtils
{
    public class CUtils
    {
		/// <summary>
		/// Register a new component into the <see cref="Planetbase.ComponentTypeList"/> so that it can be added to modules later.
		/// </summary>
		/// <returns><see cref="System.Boolean"/>: true if sucessful, false if not. (To be implemented)</returns>
		public static void registerComponent(ComponentType newCompType) {
			TypeList<ComponentType, ComponentTypeList>.getInstance().add(newCompType);
		}

		/// <summary>
		/// Add a <see cref="Planetbase.ComponentType"/> to a <see cref="Planetbase.ModuleType"/>'s build list at a specific postion.
		/// </summary>
		/// <typeparam name="CompT">Component type to add.</typeparam>
		/// <typeparam name="ModuleT">Module type to add to.</typeparam>
		/// <param name="position">The position in the Module list to add the new component to.</param>
		public static void addComponentToModuleAtPos<CompT,ModuleT>(byte position) 
		where CompT : ComponentType where ModuleT : ModuleType {
			ModuleT module = TypeList<ModuleType, ModuleTypeList>.find<ModuleT>() as ModuleT;
			List<ComponentType> components = module.mComponentTypes.ToList();
			components.Insert(position, TypeList<ComponentType, ComponentTypeList>.find<CompT>());
			module.mComponentTypes = components.ToArray();
		}

		/// <summary>
		/// Add a <see cref="Planetbase.ComponentType"/> to a <see cref="Planetbase.ModuleType"/>'s build list at the end.
		/// </summary>
		/// <typeparam name="CompT">Component type to add.</typeparam>
		/// <typeparam name="ModuleT">Module type to add to.</typeparam>
		public static void addComponentToModule<CompT, ModuleT>()
		where CompT : ComponentType where ModuleT : ModuleType {
			ModuleT module = TypeList<ModuleType, ModuleTypeList>.find<ModuleT>() as ModuleT;
			List<ComponentType> components = module.mComponentTypes.ToList();
			components.Add(TypeList<ComponentType, ComponentTypeList>.find<CompT>());
			module.mComponentTypes = components.ToArray();
		}
	}
}
