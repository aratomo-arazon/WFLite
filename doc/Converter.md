# Converter

## Description

Converter is an element for converting data and is used with variables. Examples of using the predefined converters are shown below.


<pre><code>var c1 = new CastConverter&lt;int&gt;();
var c2 = new DictionaryConverter()
{
    Dictionary = new Dictionary<</>object, object>()
    {
        { 1, "Jan" }, { 2, "Feb" }, { 3, "Mar" }
    },
    Default = "Unknown"
};

var v1 = new AnyVariable() { Value = "20", Converter = c1 };    // 20
var v2 = new AnyVariable() { Value = 2, Converter = c2 };       // "Feb"
</code></pre>

You can create custom converters by inheriting the `Converter` class. 

<pre><code>public class MillisecondToSecondConverter : Converter
{
    protected override object convert(object value)
    {
        return Convert.ToDouble(value) / 1000.0;
    }
}
</code></pre>

## References

Interfaces

* [IConverter](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Interfaces/IConverter.md)

Base classes

* [Converter](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Bases/Converter.md)

Predifined classes

* [CastConverter&lt;TValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Converters/CastConverter_TValue.md)
* [DictionaryConverter](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Converters/DictionaryConverter.md)
* [FuncConverter](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Converters/FuncConverter.md)
* [ParseConverter](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Converters/ParseConverter.md)
* [ToStringConverter](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Converters/ToStringConverter.md)