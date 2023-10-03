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

using System;
using System.IO;
using System.Text.Json;
using MGCBExtensionExample.Library;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MGCBExtensionExample.Pipeline;


[ContentImporter(".json", DisplayName = "Example Model Importer - Aristurtle", DefaultProcessor = nameof(ExampleModelProcessor))]
public class ExampleModelImporter : ContentImporter<ExampleModel>
{
    ///////////////////////////////////////////////////////////////////////////
    ///  Call this from the console application when debugging/testing
    ///////////////////////////////////////////////////////////////////////////
    public ExampleModel Import(string filename) => ImportInternal(filename, null);

    ///////////////////////////////////////////////////////////////////////////
    /// This is the one called by the MGCB Editor which provides the actual 
    /// ContentImporterContext
    ///////////////////////////////////////////////////////////////////////////
    public override ExampleModel Import(string filename, ContentImporterContext context) =>
        ImportInternal(filename, context);

    ///////////////////////////////////////////////////////////////////////////
    ///  This is the internal implementation method that both above call into.
    ///////////////////////////////////////////////////////////////////////////
    private ExampleModel ImportInternal(string filename, ContentImporterContext context)
    {
        //  Read file contents, which should be json
        string json = File.ReadAllText(filename);

        //  Deserialize to an ExampleModel which exists in the middle layer MGCBExtensionExample.Library class library
        //  If an exception is thrown here, we know there was an issue importing the data. Maybe it's not json,
        //  maybe it's not structured as an ExampleModel. Whatever the case, be sure you include an appropriate
        //  exception message to appear in the MGCB Editor for users to know what happened

        ExampleModel model;
        try
        {
            model = JsonSerializer.Deserialize<ExampleModel>(json);
        }
        catch (Exception ex)
        {
            throw new Exception($"There as an error deserializing the json when importing the file '{filename}'.  See inner exception for details", ex);
        }

        return model;
    }
}
