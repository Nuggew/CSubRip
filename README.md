# CSubRip
A SubRip decoder made for CSharp .NET Framework
<br>
<img src="https://img.shields.io/badge/build-passing-brightgreen"></img>

## How to install?
To make the using more easy, the library DLL download is avaible on the [releases](https://github.com/Nuggew/CSubRip/releases) page.

## How to use?
This library is the simplest that it could be!
```
using CSubRip;

public class Program
{
  void Main(string[] args)
  {
    List<CSubRip.SubRipParagraph> srtParagraphs = CSubRip.Decoder.DecodeToObject("[SUBRIP STRING HERE]");
    // YOUR CODE HERE!
  }
}
```

## How is the structure of a SubRip file?
Thats the basic structure of a SubRip (.srt) file!
```
1
00:00:00,000 -> 00:10:00,000
Hello World!

2
00:10:00,000 -> 01:00:00,000
This message will be in screen for the next 50 minutes...
```
