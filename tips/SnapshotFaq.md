# FAQ

## How's this different than moving the statement pointer ![yellow arrow icon](SnapshotFaq-StatementArrow.png)?

When the statement pointer is used to indicate where the application being debugging is paused. Moving it either by dragging the icon, using set next statement or `ctrl + click` on the run to glyph ![Run to glyph](SnapshotFaq-RunToClickIcon.png) changes the next statement that will execute but it does not change the state of the program. *Step Back* on the other hand doesn't change what will happen next when you resume your application what it does do is show you the eniteriy of your applications state at that previous point in time. 

## Can I see _everything_?

Pretty much. *Step Back* isn't magic so external state such as web, SQL, or local resources will have had their state changed and inspecting them will show there current, not historic, values.

## How slow is this?

Taking a snapshot typically takes between 30ms and 160ms. Which is pretty fast. 

## I don't always seem to get a snapshot, what gives?

We take snapshots everytime you stop in the debugger. This can be because you hit a breakpoint or because you have stepped and now paused on the next 'step'. However, if you are 'fast stepping' (imagine holding down the F10 key) then VS will not take a snapshot and will step the program as fast as possible.

## Can I change the state of my application then resume?
No. Snapshots are read only. You can't change the state of your application and then run forwards with that change. That's just too trippy. 