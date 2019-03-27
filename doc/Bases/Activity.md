# Activity Class

Activity class is the base class of all activity classes.

<pre><code>public abstract class Activity : IActivity
</code></pre>

## Constructors

### public Activity()

Initializes a new instance of the Activity class.

## Properties

### public [ActivityStatus](https://github.com/aratomo-arazon/WFLite/tree/master/doc/Enums/ActivityStatus.md) Status

## Methods

### public Task Start()

Starts the activity.

### public void Stop()

Stops the activity.

### public void Reset()

Resets the activity.

### protected abstract void initialize()

Initializes the activity. 

### protected abstract Task start()

Starts the activity.

### protected abstract void stop()

Stops the activity.

### protected abstract void reset()

Resets the activity.