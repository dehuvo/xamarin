package com.example.topcredu.helloaar;

public class SayHelloImpl implements SayHello {
  @Override
  public String sayHello(String name) {
    return "Hello " + name;
  }
}
