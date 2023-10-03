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

using MGCBExtensionExample.Library;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace MGCBExtensionExample.Pipeline;

[ContentProcessor(DisplayName = "Example Json Processor - Aristurtle")]
public class ExampleModelProcessor : ContentProcessor<ExampleModel, ExampleModel>
{
    ///////////////////////////////////////////////////////////////////////////
    ///  Call this from the console application when debugging/testing
    ///////////////////////////////////////////////////////////////////////////
    public ExampleModel Process(ExampleModel input) => ProcessInternal(input, null);


    ///////////////////////////////////////////////////////////////////////////
    /// This is the one called by the MGCB Editor which provides the actual 
    /// ContentImporterContext
    ///////////////////////////////////////////////////////////////////////////
    public override ExampleModel Process(ExampleModel input, ContentProcessorContext context) =>
        ProcessInternal(input, context);


    ///////////////////////////////////////////////////////////////////////////
    ///  This is the internal implementation method that both above call into.
    ///////////////////////////////////////////////////////////////////////////
    public ExampleModel ProcessInternal(ExampleModel input, ContentProcessorContext context)
    {
        //  If you need to do any processing, do it here. I don't for this example?
        //  But if you do, do it here

        return input;
    }
}