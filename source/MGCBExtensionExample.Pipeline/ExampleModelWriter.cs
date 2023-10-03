///////////////////////////////////////////////////////////////////////////////
/// MIT License
///
/// Copyright (c) 2023 Christopher Whitley
///
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
///
/// The above copyright notice and this permission notice shall be included in all
/// copies or substantial portions of the Software.
///
/// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
/// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
/// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
/// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
/// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
/// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
/// SOFTWARE.
///////////////////////////////////////////////////////////////////////////////
///
using System.IO;
using MGCBExtensionExample.Library;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace MGCBExtensionExample.Pipeline;

[ContentTypeWriter]
public sealed class ExampleModelWriter : ContentTypeWriter<ExampleModel>
{

    ///////////////////////////////////////////////////////////////////////////
    ///  Call this from the console application when debugging/testing
    ///////////////////////////////////////////////////////////////////////////
    public byte[] Write(ExampleModel content)
    {
        using MemoryStream memoryStream = new MemoryStream();
        using BinaryWriter writer = new BinaryWriter(memoryStream);

        //  The MonoGame ContentWriter is a child class of BinaryWriter
        //  It will prepend some header information to the xnb file it outputs, so
        //  you will not get that here, but you will get the raw byte[] that your
        //  file outputs otherwise
        WriteInternal(writer, content);

        return memoryStream.ToArray();
    }


    ///////////////////////////////////////////////////////////////////////////
    /// This is the one called by the MGCB Editor which provides the actual 
    /// ContentWriter instance
    ///////////////////////////////////////////////////////////////////////////
    protected override void Write(ContentWriter writer, ExampleModel content) =>
        WriteInternal(writer, content);


    ///////////////////////////////////////////////////////////////////////////
    ///  This is the internal implementation method that both above call into.
    ///////////////////////////////////////////////////////////////////////////
    private void WriteInternal(BinaryWriter writer, ExampleModel content)
    {
        writer.Write(content.ID);
        writer.Write(content.X);
        writer.Write(content.Y);
    }

    public override string GetRuntimeType(TargetPlatform targetPlatform) =>
        "MGCBExtensionExample.Library.ExampleModel, MGCBExtensionExample.Library";

    public override string GetRuntimeReader(TargetPlatform targetPlatform) =>
        "MGCBExtensionExample.Library.Readers.ExampleModelReader, MGCBExtensionExample.Library";
}