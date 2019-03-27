# InOutVariable Class
InOutVariable class is a base class of input/output variable classes.
<pre><code>public abstract class InOutVariable : IOutVariable, IInVariable
</code></pre>

## Constructors

### public InOutVariable()

Initializes a new instance of the InOutVariable class.

### public InOutVariable([IConverter]() converter = null)

Initializes a new instance of the InOutVariable class by using the specified converter.

## Properties

### public [IConverter]() Converter

Sets the converter.

## Methods

### public object GetValueAsObject()

Gets the value.

### public object GetValue()

Gets the value.

### public TOutValue GetValue&lt;TOutValue&gt;()
Gets the value.