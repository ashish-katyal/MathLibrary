//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MathLibrary {
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
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MathLibrary.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to ).
        /// </summary>
        internal static string CloseBracket {
            get {
                return ResourceManager.GetString("CloseBracket", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cant&apos;t divide by zero.
        /// </summary>
        internal static string DivideByZero {
            get {
                return ResourceManager.GetString("DivideByZero", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Expression.
        /// </summary>
        internal static string InvalidExpression {
            get {
                return ResourceManager.GetString("InvalidExpression", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Input.
        /// </summary>
        internal static string InvalidInput {
            get {
                return ResourceManager.GetString("InvalidInput", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Number of operands are invalid.
        /// </summary>
        internal static string InvalidOperands {
            get {
                return ResourceManager.GetString("InvalidOperands", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operator not available.
        /// </summary>
        internal static string InvalidOperator {
            get {
                return ResourceManager.GetString("InvalidOperator", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (.
        /// </summary>
        internal static string OpenBracket {
            get {
                return ResourceManager.GetString("OpenBracket", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Operand Count of Operation is invalid.
        /// </summary>
        internal static string OperandCountInvalid {
            get {
                return ResourceManager.GetString("OperandCountInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Number of operands are not valid for this operation.
        /// </summary>
        internal static string OperandCountNotValid {
            get {
                return ResourceManager.GetString("OperandCountNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t find square root of a negative number.
        /// </summary>
        internal static string SqrtOfNegative {
            get {
                return ResourceManager.GetString("SqrtOfNegative", resourceCulture);
            }
        }
    }
}
