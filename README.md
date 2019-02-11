# ScriptableReactive
This repostory is meant to be used as a submodule inside a Unity Project

Requires UniRX: https://github.com/neuecc/UniRx

UniRX is a reactive framework, making it possible to handle events and data, in extremly flexible ways.


This library adds onto that functionallity, by being able to define const data, reactive properties, reactive events, through scriptable objects. This is great for decoupling data and events.

The core concept is quite similar to the talk Ryan Hipple gave on scriptable objects: https://youtu.be/raQ3iHhE_Kk
But this library has the added flexibility of the reactive framework, making it possible to filter callbacks on data changes or events.
