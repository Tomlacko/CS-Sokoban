﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Tento kód byl generován nástrojem.
//     Verze modulu runtime:4.0.30319.42000
//
//     Změny tohoto souboru mohou způsobit nesprávné chování a budou ztraceny,
//     dojde-li k novému generování kódu.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sokoban.Properties {
    using System;
    
    
    /// <summary>
    ///   Třída prostředků se silnými typy pro vyhledávání lokalizovaných řetězců atp.
    /// </summary>
    // Tato třída byla automaticky generována třídou StronglyTypedResourceBuilder
    // pomocí nástroje podobného aplikaci ResGen nebo Visual Studio.
    // Chcete-li přidat nebo odebrat člena, upravte souboru .ResX a pak znovu spusťte aplikaci ResGen
    // s parametrem /str nebo znovu sestavte projekt aplikace Visual Studio.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Vrací instanci ResourceManager uloženou v mezipaměti použitou touto třídou.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Sokoban.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Potlačí vlastnost CurrentUICulture aktuálního vlákna pro všechna
        ///   vyhledání prostředků pomocí třídy prostředků se silnými typy.
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
        ///   Vyhledává lokalizovaný prostředek typu System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap crate {
            get {
                object obj = ResourceManager.GetObject("crate", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Vyhledává lokalizovaný prostředek typu System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap crate_endpoint {
            get {
                object obj = ResourceManager.GetObject("crate_endpoint", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Vyhledává lokalizovaný prostředek typu System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap empty {
            get {
                object obj = ResourceManager.GetObject("empty", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Vyhledává lokalizovaný prostředek typu System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap endpoint {
            get {
                object obj = ResourceManager.GetObject("endpoint", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Vyhledává lokalizovaný prostředek typu System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ground {
            get {
                object obj = ResourceManager.GetObject("ground", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Vyhledává lokalizovaný prostředek typu System.Drawing.Icon podobný (Ikona).
        /// </summary>
        internal static System.Drawing.Icon icon {
            get {
                object obj = ResourceManager.GetObject("icon", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Vyhledává lokalizovaný prostředek typu System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap player {
            get {
                object obj = ResourceManager.GetObject("player", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Vyhledává lokalizovaný prostředek typu System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap wall {
            get {
                object obj = ResourceManager.GetObject("wall", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
