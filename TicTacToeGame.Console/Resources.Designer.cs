﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TicTacToeGame.Console {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TicTacToeGame.Console.Resources", typeof(Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to AI is gonna move. Press enter to continue or q! to quit..
        /// </summary>
        public static string AIIsGonnaMove {
            get {
                return ResourceManager.GetString("AIIsGonnaMove", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to AI WINS! Press any key to restart game..
        /// </summary>
        public static string AiWins {
            get {
                return ResourceManager.GetString("AiWins", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DRAW! Press any key to restart game..
        /// </summary>
        public static string Draw {
            get {
                return ResourceManager.GetString("Draw", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to MOVEMENT NOT ALLOWED. PLEASE ENTER NEW COORDINATES..
        /// </summary>
        public static string NotAllowedMovement {
            get {
                return ResourceManager.GetString("NotAllowedMovement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Press 1 to let AI make the first movement.
        ///Press 2 to make you the first movement..
        /// </summary>
        public static string SelectPlayer {
            get {
                return ResourceManager.GetString("SelectPlayer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid option..
        /// </summary>
        public static string SelectPlayer_InvalidOption {
            get {
                return ResourceManager.GetString("SelectPlayer_InvalidOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Write the coordinates where you want to move.
        ///The format is [row],[column].
        ///Write q! to quit..
        /// </summary>
        public static string WriteCoordinates {
            get {
                return ResourceManager.GetString("WriteCoordinates", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to YOU WIN! Press any key to restart game..
        /// </summary>
        public static string YouWin {
            get {
                return ResourceManager.GetString("YouWin", resourceCulture);
            }
        }
    }
}
