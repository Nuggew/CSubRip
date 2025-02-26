# CSubRip<br><a href="https://github.com/Nuggew/CSubRip/releases"><img src="https://img.shields.io/badge/build-passing-brightgreen"></img></a> ![GitHub last commit (branch)](https://img.shields.io/github/last-commit/Nuggew/CSubRip/main)
A SubRip encoder/decoder made for CSharp .NET Framework

## How to install?
The library DLL download is avaible on the [releases](https://github.com/Nuggew/CSubRip/releases) page.

## How to use?
This library is the simpler that it could be!
```c#
using CSubRip;

public class Program
{
  void Main(string[] args)
  {
    List<SubRipParagraph> srtParagraphs = Decoder.DecodeToObject("[SUBRIP STRING HERE]");
    // YOUR CODE HERE!
  }
}
```

## How is the structure of a SubRip file?
Thats the basic structure of a SubRip (.srt) file!
```srt
1
00:00:00,000 -> 00:10:00,000
Hello World!

2
00:10:00,000 -> 01:00:00,000
This message will be in screen for the next 50 minutes...
```
