//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option or rebuild the Visual Studio project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Web.Application.StronglyTypedResourceProxyBuilder", "10.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Formats {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Formats() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resources.Formats", global::System.Reflection.Assembly.Load("App_GlobalResources"));
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
        ///   Looks up a localized string similar to {0:C0}.
        /// </summary>
        internal static string CURRENCY {
            get {
                return ResourceManager.GetString("CURRENCY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:dd-MM-yyyy}.
        /// </summary>
        internal static string DATE {
            get {
                return ResourceManager.GetString("DATE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:dd MMMM yyyy}.
        /// </summary>
        internal static string FULL_DATE {
            get {
                return ResourceManager.GetString("FULL_DATE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:N0}.
        /// </summary>
        internal static string NUMBER {
            get {
                return ResourceManager.GetString("NUMBER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:N0}%.
        /// </summary>
        internal static string PERCENT {
            get {
                return ResourceManager.GetString("PERCENT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:N}.
        /// </summary>
        internal static string REAL_NUMBER {
            get {
                return ResourceManager.GetString("REAL_NUMBER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:dddd, dd MMMM yyyy HH&apos;:&apos;mm&apos;:&apos;ss &apos;GMT&apos;}.
        /// </summary>
        internal static string RFC_DATE {
            get {
                return ResourceManager.GetString("RFC_DATE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0:dd-MM-yyyy hh:mm:ss}.
        /// </summary>
        internal static string UPDATE_DATE {
            get {
                return ResourceManager.GetString("UPDATE_DATE", resourceCulture);
            }
        }
    }
}
