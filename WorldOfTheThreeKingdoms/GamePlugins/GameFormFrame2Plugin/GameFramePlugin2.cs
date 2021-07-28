using GameFreeText;
using GameGlobal;
using GameManager;
using GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platforms;
using PluginInterface;
using PluginInterface.BaseInterface;
using System;
//using System.Drawing;
using System.Xml;
using WorldOfTheThreeKingdoms;

namespace GameFormFramePlugin2
{

    public class GameFramePlugin2 : GameObject, IGameFrame2, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"Content\Textures\GameComponents\gameFrame2\Data\";
        private string description = "窗体的框架";
        private GameFrame2 gameFrame2 = new GameFrame2();

        private const string Path = @"Content\Textures\GameComponents\gameFrame2\";
        private string pluginName = "gameFrame2Plugin";
        private string version = "1.0.0";
        private const string XMLFilename = "gameFrame2Data.xml";

        public void Cancel()
        {
            this.gameFrame2.DoCancel();
        }

        public void Dispose()
        {
        }

        public void Draw()
        {
            this.gameFrame2.Draw();
        }

        public void Initialize(Screen screen)
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            Font font;
            Microsoft.Xna.Framework.Color color;
            XmlDocument document = new XmlDocument();

            string xml = Platform.Current.LoadText(filename);
            document.LoadXml(xml);

            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.gameFrame2.leftedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.leftedgeTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(1);
            this.gameFrame2.rightedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.rightedgeTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(2);
            this.gameFrame2.topedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.topedgeTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(3);
            this.gameFrame2.bottomedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.bottomedgeTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(4);
            this.gameFrame2.backgroundTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(5);
            this.gameFrame2.okbuttonSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.okbuttonSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.gameFrame2.okbuttonTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.gameFrame2.okbuttonSelectedTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.gameFrame2.okbuttonPressedTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("Pressed").Value);
            this.gameFrame2.okbuttonDisabledTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(6);
            this.gameFrame2.cancelbuttonSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.cancelbuttonSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.gameFrame2.cancelbuttonTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.gameFrame2.cancelbuttonSelectedTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.gameFrame2.cancelbuttonPressedTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("Pressed").Value);
            this.gameFrame2.cancelbuttonDisabledTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(7);
            this.gameFrame2.titleWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.titleHeight = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.gameFrame2.titleTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.gameFrame2.TitleText = new FreeText(font, color);
            this.gameFrame2.TitleText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(8);
            this.gameFrame2.OKSoundFile = @"Content\Sound\" + node.Attributes.GetNamedItem("OK").Value;
            this.gameFrame2.CancelSoundFile = @"Content\Sound\" + node.Attributes.GetNamedItem("Cancel").Value;
            node = nextSibling.ChildNodes.Item(9);
            this.gameFrame2.mapviewselectorbuttonSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.mapviewselectorbuttonSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.gameFrame2.MapViewSelectorButtonTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.gameFrame2.MapViewSelectorButtonSelectedTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("Selected").Value);


            node = nextSibling.ChildNodes.Item(10);
            //this.gameFrame2.TopLeftWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.TopLeftTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(11);
            //this.gameFrame2.TopRightWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.TopRightTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(12);
            //this.gameFrame2.BottomLeftWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.BottomLeftTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(13);
            //this.gameFrame2.BottomRightWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.BottomRightTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            /*
            node = nextSibling.ChildNodes.Item(14);
            this.gameFrame2.selectallbuttonSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.gameFrame2.selectallbuttonSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.gameFrame2.selectallbuttonTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame2\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.gameFrame2.selectallbuttonSelectedTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame2\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.gameFrame2.selectallbuttonPressedTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame2\Data\" + node.Attributes.GetNamedItem("Pressed").Value);
            this.gameFrame2.selectallbuttonDisabledTexture = CacheManager.GetTempTexture(@"Content\Textures\GameComponents\gameFrame2\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
             */
        }

        public void OK()
        {
            this.gameFrame2.DoOK();
        }
        /*
        public void SelectAll()
        {
            this.gameFrame2.DoSelectAll();
        }
        
        public void SetSelectAllFunction(GameDelegates.VoidFunction function)
        {
            this.gameFrame2.SetSelectAllFunction(function);
        }
        */
        public void SetCancelFunction(GameDelegates.VoidFunction function)
        {
            this.gameFrame2.SetCancelFunction(function);
        }

        public void SetFrameContent(object content, Microsoft.Xna.Framework.Point viewportSize)
        {
            if (content is FrameContent)
            {
                this.gameFrame2.SetFrameContent(content as FrameContent, viewportSize);
            }
        }

        public void SetGraphicsDevice()
        {
            this.LoadDataFromXMLDocument(@"Content\Data\Plugins\GameFrameData.xml");
        }

        public void SetOKFunction(GameDelegates.VoidFunction function)
        {
            this.gameFrame2.SetOKFunction(function);
        }

        public void SetScreen(Screen screen)
        {
            this.gameFrame2.Initialize();
        }

        public void Update(GameTime gameTime)
        {
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public bool CancelButtonEnabled
        {
            get
            {
                return this.gameFrame2.CancelButtonEnabled;
            }
            set
            {
                this.gameFrame2.CancelButtonEnabled = value;
            }
        }
        /*
        public bool SelectAllButtonEnabled
        {
            get
            {
                return this.gameFrame2.SelectAllButtonEnabled;
            }
            set
            {
                this.gameFrame2.SelectAllButtonEnabled = value;
            }
        }
        */
        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public FrameFunction Function
        {
            get
            {
                return this.gameFrame2.Function;
            }
            set
            {
                this.gameFrame2.Function = value;
            }
        }

        public object Instance
        {
            get
            {
                return this;
            }
        }

        public bool IsShowing
        {
            get
            {
                return this.gameFrame2.IsShowing;
            }
            set
            {
                this.gameFrame2.IsShowing = value;
            }
        }

        public FrameKind Kind
        {
            get
            {
                return this.gameFrame2.Kind;
            }
            set
            {
                this.gameFrame2.Kind = value;
            }
        }

        public bool OKButtonEnabled
        {
            get
            {
                return this.gameFrame2.OKButtonEnabled;
            }
            set
            {
                this.gameFrame2.OKButtonEnabled = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public FrameResult Result
        {
            get
            {
                return this.gameFrame2.Result;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }

        public int LeftEdge
        {
            get
            {
                return this.gameFrame2.leftedgeWidth;
            }
        }

        public int RightEdge
        {
            get
            {
                return this.gameFrame2.rightedgeWidth;
            }
        }

        public int TopEdge
        {
            get
            {
                return this.gameFrame2.topedgeWidth;
            }
        }

        public int BottomEdge
        {
            get
            {
                return this.gameFrame2.bottomedgeWidth;
            }
        }
    }
}

