# Converter&lt;TValue&gt; Class

Converter&lt;TValue&gt; class is a base class of converter classes.

<pre><code>public abstract class Converter&lt;TValue&gt; : IConverter&lt;TValue&gt;
</code></pre>

## Constructors

### public Converter()

Initializes a new isntance of the Converter class.

## Methods

### public object ConvertToObject(object value)

Converts the value.

### public TValue Convert(object value)

Converts the value.

### protected abstract TValue convert(object value)

Converts the value.