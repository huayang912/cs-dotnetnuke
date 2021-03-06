#region DotNetNuke License
// DotNetNukeŽ - http://www.dotnetnuke.com
// Copyright (c) 2002-2006
// by DotNetNuke Corporation
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion
using System;
using System.Collections;
using System.Xml;

namespace DotNetNuke.UI.WebControls
{
    public class MenuNodeEnumerator : IEnumerator
    {
        private XmlNode m_objXMLNode;
        private DNNMenu m_objDNNMenu;
        private int m_intCursor;

        public MenuNodeEnumerator( XmlNode objRoot, DNNMenu objControl )
        {
            m_objXMLNode = objRoot;
            m_objDNNMenu = objControl;
            m_intCursor = -1;
        }

        public void Reset()
        {
            m_intCursor = -1;
        }

        public bool MoveNext()
        {
            if( m_intCursor < m_objXMLNode.ChildNodes.Count )
            {
                m_intCursor++;
            }

            if( m_intCursor == m_objXMLNode.ChildNodes.Count )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object Current
        {
            get
            {
                if( ( m_intCursor < 0 ) || ( m_intCursor == m_objXMLNode.ChildNodes.Count ) )
                {
                    throw ( new InvalidOperationException() );
                }
                else
                {
                    return new MenuNode( m_objXMLNode.ChildNodes[m_intCursor], m_objDNNMenu );
                }
            }
        }
    }
}