These samples use the 'Castle Windsor' IoC framework, version 2.0. This is done 
by referencing the four Castle assemblies. For further reading on Castle Windsor, 
see http://www.castleproject.org/container/gettingstarted/index.html

Here is some text from the Castle Project website:

===================================================
Castle Windsor might look like a complex beast at first, and for newcomers it might add 
more complexity to a system design than simplification.

That is because to use them properly you need to learn to develop loosely coupled system 
architecture. While this might sound simple or even obvious, in practice it is not. First 
of all you have to learn to give classes just one concern, one goal, one task (or family 
of related tasks) and preferably expose services contracts.

Nothing new so far, this is -- unarguably -- an OOP goal. But look at your application: 
are they really not tight coupled? Is there any code that request a service directly and 
configure it before using it? Aren't you using a Service Locator and a singleton and doing 
hacks to allow the classes to be testable?

Inversion of Control containers allow you to achieve loosely coupled designs and they 
handle dependency and configuration management when you, or a class in your system, request 
a service to say, send e-mails, you will get an instance ready to be used. If this sounds 
vague, keep reading and you will see what we are talking about. 
===================================================

Start with example 1. and work your way through.