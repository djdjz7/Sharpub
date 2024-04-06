# Sharpub
A C# library for creating EPUB books.

This library (hopefully) strictly follows the EPUB 3.3 specification.

This project is still in development.

## Usage
All APIs are under development.

### Create an EPUB instance
~~~csharp
var meta = new EpubMetadata("Example Book", "en-US");
var epub = new EpubBook(meta);
~~~

### Add a chapter
TO DO

### Add an image
TO DO

### Export the book
~~~csharp
await epub.ExportAsync("example.epub");
~~~