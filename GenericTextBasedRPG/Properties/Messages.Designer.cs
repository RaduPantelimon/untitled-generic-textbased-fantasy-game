﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenericRPG.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GenericRPG.Properties.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attack!.
        /// </summary>
        internal static string Command_Attack {
            get {
                return ResourceManager.GetString("Command_Attack", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Flee! (shameful display).
        /// </summary>
        internal static string Command_Flee {
            get {
                return ResourceManager.GetString("Command_Flee", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command Selection Error: {0}.
        /// </summary>
        internal static string Command_InvalidCommand {
            get {
                return ResourceManager.GetString("Command_InvalidCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Quit Game.
        /// </summary>
        internal static string Command_QuitGame {
            get {
                return ResourceManager.GetString("Command_QuitGame", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Quit Level.
        /// </summary>
        internal static string Command_QuitLevel {
            get {
                return ResourceManager.GetString("Command_QuitLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To Battle!.
        /// </summary>
        internal static string Command_StartFight {
            get {
                return ResourceManager.GetString("Command_StartFight", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start Game.
        /// </summary>
        internal static string Command_StartGame {
            get {
                return ResourceManager.GetString("Command_StartGame", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start Next Level.
        /// </summary>
        internal static string Command_StartLevel {
            get {
                return ResourceManager.GetString("Command_StartLevel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Chose the enemy you would like to attack:.
        /// </summary>
        internal static string Menu_ChooseMobToAttack {
            get {
                return ResourceManager.GetString("Menu_ChooseMobToAttack", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please Select One of the following commands by replying with the corresponding number:.
        /// </summary>
        internal static string Menu_EligibleCommands {
            get {
                return ResourceManager.GetString("Menu_EligibleCommands", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}. {1}(HP: {2}).
        /// </summary>
        internal static string Menu_MobDisplayTemplate {
            get {
                return ResourceManager.GetString("Menu_MobDisplayTemplate", resourceCulture);
            }
        }
    }
}
