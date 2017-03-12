using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		public static void addComponentToModule<CompT,ModuleT>() 
			where CompT : ComponentType 
			where ModuleT : ModuleType {
			ModuleT module = TypeList<ModuleType, ModuleTypeList>.find<ModuleT>() as ModuleT;
			List<ComponentType> components = module.mComponentTypes.ToList();
			components.Insert(3, TypeList<ComponentType, ComponentTypeList>.find<CompT>());
			module.mComponentTypes = components.ToArray();
        }
    }
}
