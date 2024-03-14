﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Teshigoto.UnitTests.Generation.Resources {
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
    internal class Interfaces {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Interfaces() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Teshigoto.UnitTests.Generation.Resources.Interfaces", typeof(Interfaces).Assembly);
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
        ///   Looks up a localized string similar to namespace Teshigoto.CompilationTests.Interfaces;
        ///
        ////// &lt;summary&gt;
        ////// Compare operators
        ////// &lt;/summary&gt;
        ////// &lt;typeparam name=&quot;T&quot;&gt;Type&lt;/typeparam&gt;
        ///public interface IComparableOperators&lt;in T&gt;
        ///    where T : IComparableOperators&lt;T&gt;
        ///{
        ///    #region Methods
        ///
        ///    /// &lt;summary&gt;
        ///    /// Returns a value that indicates whether a &lt;see cref=&quot;T:T&quot; /&gt; value is less than another &lt;see cref=&quot;T:T&quot; /&gt; value.
        ///    /// &lt;/summary&gt;
        ///    /// &lt;param name=&quot;left&quot;&gt;The first value to compare.&lt;/param&gt;
        ///    /// &lt;param name=&quot;right&quot;&gt;T [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string IComparableOperators {
            get {
                return ResourceManager.GetString("IComparableOperators", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace Teshigoto.CompilationTests.Interfaces;
        ///
        ////// &lt;summary&gt;
        ////// Equality operators
        ////// &lt;/summary&gt;
        ////// &lt;typeparam name=&quot;T&quot;&gt;Type&lt;/typeparam&gt;
        ///public interface IEqualityOperators&lt;in T&gt;
        ///    where T : IEqualityOperators&lt;T&gt;
        ///{
        ///    /// &lt;summary&gt;
        ///    /// Returns a value that indicates whether the values of two &lt;see cref=&quot;T&quot;/&gt; objects are equal.
        ///    /// &lt;/summary&gt;
        ///    /// &lt;param name=&quot;left&quot;&gt;The first value to compare.&lt;/param&gt;
        ///    /// &lt;param name=&quot;right&quot;&gt;The second value to compare.&lt;/param&gt;
        ///    /// &lt;r [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string IEqualityOperators {
            get {
                return ResourceManager.GetString("IEqualityOperators", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace Teshigoto.CompilationTests.Interfaces;
        ///
        ////// &lt;summary&gt;
        ////// Factory to create test objects
        ////// &lt;/summary&gt;
        ////// &lt;typeparam name=&quot;TObject&quot;&gt;Type of the object to be created&lt;/typeparam&gt;
        ////// &lt;typeparam name=&quot;TValue&quot;&gt;Type of the argument&lt;/typeparam&gt;
        ///public interface IFactory&lt;out TObject, in TValue&gt;
        ///{
        ///    /// &lt;summary&gt;
        ///    /// Create new instance
        ///    /// &lt;/summary&gt;
        ///    /// &lt;param name=&quot;value&quot;&gt;Value&lt;/param&gt;
        ///    /// &lt;returns&gt;Created value&lt;/returns&gt;
        ///    static abstract TObject Create(TValue value [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string IFactory1 {
            get {
                return ResourceManager.GetString("IFactory1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace Teshigoto.CompilationTests.Interfaces;
        ///
        ////// &lt;summary&gt;
        ////// Factory to create test objects
        ////// &lt;/summary&gt;
        ////// &lt;typeparam name=&quot;TObject&quot;&gt;Type of the object to be created&lt;/typeparam&gt;
        ////// &lt;typeparam name=&quot;TValue1&quot;&gt;Type of the first argument&lt;/typeparam&gt;
        ////// &lt;typeparam name=&quot;TValue2&quot;&gt;Type of the second argument&lt;/typeparam&gt;
        ///public interface IFactory&lt;out TObject, in TValue1, in TValue2&gt;
        ///{
        ///    /// &lt;summary&gt;
        ///    /// Create new instance
        ///    /// &lt;/summary&gt;
        ///    /// &lt;param name=&quot;value1&quot;&gt;Value 1&lt;/par [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string IFactory2 {
            get {
                return ResourceManager.GetString("IFactory2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace Teshigoto.CompilationTests.Interfaces;
        ///
        ////// &lt;summary&gt;
        ////// Factory to create test objects
        ////// &lt;/summary&gt;
        ////// &lt;typeparam name=&quot;TObject&quot;&gt;Type of the object to be created&lt;/typeparam&gt;
        ////// &lt;typeparam name=&quot;TValue1&quot;&gt;Type of the first argument&lt;/typeparam&gt;
        ////// &lt;typeparam name=&quot;TValue2&quot;&gt;Type of the second argument&lt;/typeparam&gt;
        ////// &lt;typeparam name=&quot;TValue3&quot;&gt;Type of the third argument&lt;/typeparam&gt;
        ///public interface IFactory&lt;out TObject, in TValue1, in TValue2, in TValue3&gt;
        ///{
        ///    /// &lt;summary&gt;
        ///    ///  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string IFactory3 {
            get {
                return ResourceManager.GetString("IFactory3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to namespace Teshigoto.CompilationTests.Interfaces;
        ///
        ////// &lt;summary&gt;
        ////// Factory to create test objects
        ////// &lt;/summary&gt;
        ////// &lt;typeparam name=&quot;TObject&quot;&gt;Type of the object to be created&lt;/typeparam&gt;
        ////// &lt;typeparam name=&quot;TValue1&quot;&gt;Type of the first argument&lt;/typeparam&gt;
        ////// &lt;typeparam name=&quot;TValue2&quot;&gt;Type of the second argument&lt;/typeparam&gt;
        ////// &lt;typeparam name=&quot;TValue3&quot;&gt;Type of the third argument&lt;/typeparam&gt;
        ////// &lt;typeparam name=&quot;TValue4&quot;&gt;Type of the fourth argument&lt;/typeparam&gt;
        ///public interface IFactory&lt;out TObje [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string IFactory4 {
            get {
                return ResourceManager.GetString("IFactory4", resourceCulture);
            }
        }
    }
}
