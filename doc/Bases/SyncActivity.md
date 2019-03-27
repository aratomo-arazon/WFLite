# SyncActivity Class

SyncActivity class is the base class of all synchronous activity classes.

<pre><code>public abstract class SyncActivity : Activity
</code></pre>

## Constructors

### public SyncActivity()

Initializes a new instance of the SyncActivity class.

## Properties

### public [ActivityStatus](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Enums/ActivityStatus.md) Status

Gets the activity status.
(Inherited from [Activity](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Bases/Activity.md))

## Methods

### public Task Start()

Starts the activity.
(Inherited from [Activity](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Bases/Activity.md))

### public void Stop()

Stops the activity.
(Inherited from [Activity](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Bases/Activity.md))

### public void Reset()

Resets the activity.
(Inherited from [Activity](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Bases/Activity.md))

### protected abstract bool run()

Runs the activity synchronously.