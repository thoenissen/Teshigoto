using Teshigoto.CompilationTests.Comparable;
using Teshigoto.Generators;

namespace Teshigoto.UnitTests.Function;

/// <summary>
/// Function tests of generated source by <see cref="ComparableGenerator"/>
/// </summary>
[TestClass]
public class ComparableGeneratorTests
{
    /// <summary>
    /// Equality tests
    /// </summary>
    [TestMethod]
    public void Equals()
    {
        ComparableTester<ClassWithOneProperty>.AssertEquals();
        ComparableTester<RecordClassWithOneProperty>.AssertEquals();
        ComparableTester<RecordStructWithOneProperty>.AssertEquals();
        ComparableTester<StructWithOneProperty>.AssertEquals();
    }

    /// <summary>
    /// Greater tests
    /// </summary>
    [TestMethod]
    public void Greater()
    {
        ComparableTester<ClassWithOneProperty>.AssertGreater();
        ComparableTester<RecordClassWithOneProperty>.AssertGreater();
        ComparableTester<RecordStructWithOneProperty>.AssertGreater();
        ComparableTester<StructWithOneProperty>.AssertGreater();
    }

    /// <summary>
    /// Less tests
    /// </summary>
    [TestMethod]
    public void Less()
    {
        ComparableTester<ClassWithOneProperty>.AssertLess();
        ComparableTester<RecordClassWithOneProperty>.AssertLess();
        ComparableTester<RecordStructWithOneProperty>.AssertLess();
        ComparableTester<StructWithOneProperty>.AssertLess();
    }
}