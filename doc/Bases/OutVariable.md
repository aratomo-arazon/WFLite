# OutVariable Class
OutVariable class is a base class of output variable classes.

<pre><code>public abstract class OutVariable : IOutVariable
</code></pre>

## Constructors

### public OutVariable()
Initializes a new instance of the OutVariable class.

### public OutVariable([IConverter](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Interfaces/IConverter.md) converter = null)
Initializes a new instance of the OutVariable class by using the specified converter.

## Properties

### public [IConverter](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Interfaces/IConverter.md) Converter

Set the converter.

## Methods

### public object GetValueAsObject()

Get the value.

### public TValue GetValue&lt;TValue&gt;()

Get the value.

### protected abstract object getValue()

Get the value.