﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace A_Team.Pages {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Templates {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Templates() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("A_Team.Pages.Templates", typeof(Templates).Assembly);
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
        ///   Looks up a localized string similar to Ali Khan, Alizay &lt;Alizay.AliKhan@kpmg.co.uk&gt;; Rathakrishnan, Vinoth &lt;Vinoth.Rathakrishnan@KPMG.co.uk&gt;; Caesar, Tafana &lt;Tafana.Caesar@kpmg.co.uk&gt; ; DE-TaxGMSITESTAnlage@kpmg.com.
        /// </summary>
        public static string CC {
            get {
                return ResourceManager.GetString("CC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hello, &lt;/br&gt; &lt;/br&gt;
        ///We are yet to receive your completed Business Traveller questionnaires for this quarter. The deadline for this was {0}, which has now passed. 
        ///&lt;/br&gt;
        ///Our Business Traveller tool is frequently used to differentiate us from our competitors in the market but it needs to be technically sound to maintain this market leading position.  Please ensure your office completes the Business Traveller questionnaire this quarter.  Your input is critical to helping our clients manage their global short [rest of string was truncated]&quot;;.
        /// </summary>
        public static string EmailBody {
            get {
                return ResourceManager.GetString("EmailBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to do.not.reply-gms@kpmg.com.
        /// </summary>
        public static string EmailFrom {
            get {
                return ResourceManager.GetString("EmailFrom", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to smtp.de.kworld.kpmg.com.
        /// </summary>
        public static string SMTPServer {
            get {
                return ResourceManager.GetString("SMTPServer", resourceCulture);
            }
        }
    }
}
