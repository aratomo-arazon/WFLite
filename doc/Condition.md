# Condition

## Description

Condition is an element expressing any condition and returns a boolean value. Examples of using the predefined conditions are shown below.

<pre><code>var v1 = new AnyVariable() { Value = true };
var v2 = new AnyVariable() { Value = 1 };
var v3 = new AnyVariable() { Value = 2 };

var c1 = new TrueCondition() { Value = v1 };       // true -> true
var c2 = new FalseCondition() { Value = v1 };      // true -> false
var c3 = new EqualsCondition()                     // 1 == 2 -> false
{
    Value1 = v2,
    Value2 = v3
};
var c4 = new NullCondition() { Value = v2 };       // 1 is null -> false
var c5 = new NotCondition() { Condition = c2 };    // !false -> true
var c6 = new OrCondition()                         // true || false -> true
{
    Conditions = new List<</>ICondition>() { c1, c2 }
};
var c7 = new AndCondition()                        // true && false -> false
{
    Conditions = new List<</>ICondition>() { c1, c2 }
};
</code></pre>
You can create custom Conditions by inheriting the `Condition` class.
<pre><code>public class MorningCondition : Condition
{
    protected override bool check()
    {
        var hour = DateTime.Now.Hour;
        return hour >= 6 && hour < 12;
    }
}
</code></pre>

## References

Interfaces

* [ICondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Interfaces/ICondition.md)

Base classes

* [Condition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Bases/Condition.md)

Predifined classes

* [TrueCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/TrueCondition.md)
* [FalseCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/FalseCondition.md)
* [EqualsCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/EqualsCondition.md)
* [NotEqualsCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/NotEqualsCondition.md)
* [GreaterThanCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/GreaterThanCondition.md)
* [LessThanCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/LessThanCondition.md)
* [NullCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/NullCondition.md)
* [NotNullCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/NotNullCondition.md)
* [ContainsCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/ContainsCondition.md)
* [FuncCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/FuncCondition.md)
* [NotCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/NotCondition.md)
* [AndCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/AndCondition.md)
* [OrCondition](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Conditions/OrCondition.md)

