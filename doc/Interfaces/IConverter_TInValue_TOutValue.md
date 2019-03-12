# IConverter&lt;TInValue,TOutValue&gt;

IConverter&lt;TInValue,TOutValue&gt; provides methods to convert a value.

<pre><code>public interface IConverter&lt;TInValue,TOutValue&gt; : IConverter&lt;TOutValue&gt;
</code></pre>

## Methods

### object ConvertToObject(object value)
Converts the value.
(Inherited from [IConverter](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Interfaces/IConverter.md))

### TOutValue Convert(object value)
Converts the value.
(Inherited from [IConverter&lt;TValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/IConverter_TValue.md))

### TOutValue Convert(TInValue value)
Converts the value.
