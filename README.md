# CSubRip
A SubRip decoder made for CSharp .NET Framework

## How to install?
To make the using more easy, the library DLL download is avaible on the <a href="https://github.com/Nuggew/CSubRip/releases">releases</a> page.

## How to use?
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
