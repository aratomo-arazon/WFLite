# OutVariable&lt;TOutValue&gt; Class

OutVariable&lt;TOutValue&gt; class is a base class of output variable classes.

<pre><code>public abstract class OutVariable&lt;TOutValue&gt; : IOutVariable&lt;TOutValue&gt;
</code></pre>

## Constructors

### public OutVariable()

Initializes a new instance of the OutVariable&lt;TValue&gt; class.

### public OutVariable([IConverter&lt;TOutValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Interfaces/IConverter_TValue.md) converter = null)

Initializes a new Instance of the OutVariable&lt;TValue&gt; class by using the specified converter.

## Properties

### public [IConverter&lt;TOutValue&gt;](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Interfaces/IConverter_TValue.md) Converter

Sets the converter.

## Methods

### public object GetValueAsObject()

Get the value.

### public TValue GetValue&lt;TValue&gt;()

Get the value.

### public TOutValue GetValue()

Get the value.

### protected abstract object getValue()

Get the value.