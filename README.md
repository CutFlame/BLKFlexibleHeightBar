
## Create condensing header bars like those seen in the Facebook, Square Cash, and Safari iOS apps.
Ported from [bryankeller/BLKFlexibleHeightBar](https://github.com/bryankeller/BLKFlexibleHeightBar).

<img src="http://foxweb.marist.edu/users/stbk/SquareCashDemo2.gif" alt="Square Cash Style Bar" width="300"/> 
<img src="http://foxweb.marist.edu/users/stbk/FacebookDemo2.gif" alt="Square Cash Style Bar" width="300"/>

`BLKFlexibleHeightBar` allows you to create header bars with flexible heights. Often, this sort of UI paradigm is used to hide chrome and make room for more content as a user is scrolling. This is seen in third party apps like Facebook and Square Cash, as well as first party apps like Safari.

`BLKFlexibleHeightBar` can create bars that look and act any way you'd like:

* Immediate subviews of a flexible height bar define how they want to look and where they want to be depending on the height of the bar. Properties like frame, transform, and alpha can all vary depending on the current height of the bar.
* A bar's behavior can be defined using a behavior definer instance. A behavior definer can be created to emulate Safari's header behavior, Facebook's header behavior, or something entirely new. Behaviors are completely modular and aren't coupled with the appearence of the bar.

Due to this library's modular, extensible nature, you are not limited to any one look or any one feel. *What UICollectionView does for presenting collections of data, `BLKFlexibleHeightBar` does for creating header bars.*



## TODO
* Include a `SafariStyleBehaviorDefiner` (uses velocity, not just scroll position).
* Support for **Auto Layout** based layout attributes would simplify some of the trickier bar designs, removing the need to perform final frame and size calculations yourself when defining layout attributes.

## Let me know what you think!
You can get in touch with me via Twitter
Original Author: [@BKyourway19](http://twitter.com/BKyourway19)
Port to Xamarin.iOS/Mono: [@HoltFlame](http://twitter.com/HoltFlame)
