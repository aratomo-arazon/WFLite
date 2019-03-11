Converter
===

Converter is an element for converting data and is used with Variable. Examples of using the predefined Converters are shown below.


<pre><code>var c1 = new CastConverter<<int>int</int>>();
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

You can create custom Converters by inheriting the `Converter` class. 

<pre><code>public class MillisecondToSecondConverter : Converter
{
    protected override object convert(object value)
    {
        return Convert.ToDouble(value) / 1000.0;
    }
}
</code></pre>