These samples do not use any third party code - this is all C# language features.

===================================================
C# 3.0 introduced "Lambdas", a feature common to many scripted languages like Python and Ruby etc. The C# operator for lambdas 
is [[ => ]]. This operator is purely syntatic sugar - it doesn't add any new functionality to the language, and the compiler
will reduce lambda expressions to their equivalent plain old C# code.

So what does this syntactic sugar buy us? Readability. Conciseness. In .NET 2.0, writing anonymous functions inline was a very 
verbose process and the code often looked ugly. With the introduction of the => operator in .NET 3.5, anonymously inline 
functions now have a very clean look. 

This conciseness allows us to push the envelope one step further and write a lot more complicated code, in a much neater way.
===================================================

Start with example 1. and work your way through.