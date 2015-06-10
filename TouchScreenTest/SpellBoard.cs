using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
namespace TouchScreenTest
{
    class SpellBoard
    {
        List<SpellCounter> spellFields;
        Vector2 location;
        Texture2D spellTextureNotSelected, spellTextureSelected;
        String debugContent = "";
        SpellCounter current;
        public SpellBoard(Texture2D spellTextureNotSelected, Texture2D spellTextureSelected, Rectangle boundingBox, Vector2 location)
        {

            this.location = location;
            this.spellTextureNotSelected = spellTextureNotSelected;
            this.spellTextureSelected = spellTextureSelected;
            spellFields = new List<SpellCounter>();

        }

        public void LoadBoard(int spellBoard)
        {
            spellFields.Clear();
            switch (spellBoard)
            {
                case 0:
                    //4 x 4 Board
                    SpellCounter spell22_1x1 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X, location.Y),1);
                    SpellCounter spell22_1x2 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + 100, location.Y),2);
                    SpellCounter spell22_2x1 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X, location.Y + 100),3);
                    SpellCounter spell22_2x2 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + 100, location.Y + 100),4);

                    spellFields.Add(spell22_1x1);
                    spellFields.Add(spell22_1x2);
                    spellFields.Add(spell22_2x1);
                    spellFields.Add(spell22_2x2);

                    break;
                case 1: 
                    //spell case level 2 3 x 3
                    SpellCounter spell33_1x1 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X, location.Y),1);
                    SpellCounter spell33_1x2 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + 50, location.Y),2);
                    SpellCounter spell33_1x3 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + 100, location.Y),3);
                    SpellCounter spell33_2x1 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X, location.Y + 50),4);
                    SpellCounter spell33_2x2 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + 50, location.Y + 50),5);
                    SpellCounter spell33_2x3 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + 100, location.Y + 50),6);
                    SpellCounter spell33_3x1 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X, location.Y + 100),7);
                    SpellCounter spell33_3x2 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + 50, location.Y + 100),8);
                    SpellCounter spell33_3x3 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + 100, location.Y + 100),9);


                    spellFields.Add(spell33_1x1);
                    spellFields.Add(spell33_1x2);
                    spellFields.Add(spell33_1x3);
                    spellFields.Add(spell33_2x1);
                    spellFields.Add(spell33_2x2);
                    spellFields.Add(spell33_2x3);
                    spellFields.Add(spell33_3x1);
                    spellFields.Add(spell33_3x2);
                    spellFields.Add(spell33_3x3);

                    break;
                case 2:
                    //spell cast level 3
                    SpellCounter spellult_1 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .5), location.Y + (float)(200 * .025)),1);
                    SpellCounter spellult_2 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .725), location.Y + (float)(200 * .1)),2);
                    SpellCounter spellult_3 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .9), location.Y + (float)(200 * .275)),3);
                    SpellCounter spellult_4 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .975), location.Y + (float)(200 * .5)),4);
                    SpellCounter spellult_5 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .9), location.Y + (float)(200 * .725)),5);
                    SpellCounter spellult_6 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .725), location.Y + (float)(200 * .9)),6);
                    SpellCounter spellult_7 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .5), location.Y + (float)(200 * .975)),7);
                    SpellCounter spellult_8 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .275), location.Y + (float)(200 * .9)),8);
                    SpellCounter spellult_9 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .1), location.Y + (float)(200 * .725)),9);
                    SpellCounter spellult_10 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .025), location.Y + (float)(200 * .5)),10);
                    SpellCounter spellult_11 = new SpellCounter(spellTextureNotSelected, spellTextureSelected, new Vector2(location.X + (float)(200 * .1), location.Y + (float)(200 * .275)),11);
                    SpellCounter spellult_12 = new SpellCounter(spellTextureNotSelected,spellTextureSelected, new Vector2(location.X + (float)(200 * .275), location.Y + (float)(200 * .1)),12);

                    spellFields.Add(spellult_1);
                    spellFields.Add(spellult_2);
                    spellFields.Add(spellult_3);
                    spellFields.Add(spellult_4);
                    spellFields.Add(spellult_5);
                    spellFields.Add(spellult_6);
                    spellFields.Add(spellult_7);
                    spellFields.Add(spellult_8);
                    spellFields.Add(spellult_9);
                    spellFields.Add(spellult_10);
                    spellFields.Add(spellult_11);
                    spellFields.Add(spellult_12);

                    break;
            }
        }
        public void Update(GameTime gameTime, TouchCollection touchCollection)
        {
            bool revertAll = touchCollection.Count == 0;
            debugContent = "";

            debugContent += "RevertAll:" + revertAll.ToString() + Environment.NewLine;
            for (int i = 0; i < spellFields.Count; i++)
            {

                SpellCounter spellCounter = spellFields[i];
                
                if (revertAll)
                {
                    current = null;
                    spellCounter.UpdateState(SpellCounterState.NotSelected);
                    spellCounter.ClearConnectors();
                }
                else
                {
                    debugContent += "Element[" + i + "]: "; 
                    for (int j = 0; j < touchCollection.Count; j++) {
                        debugContent += spellCounter.isInside(touchCollection[j].Position) + ",";
                        if (spellCounter.isInside(touchCollection[j].Position))
                        {
                            
                            spellCounter.UpdateState(SpellCounterState.Selected);
                            if(current != null && current.id != spellCounter.id)
                                current.AddConnector(spellCounter);
                            current = spellCounter;
                        }
                    }
                    debugContent += Environment.NewLine;
                }
                
            }

            String currentSpell = SpellChecker.GetSpellBuild(spellFields);
            debugContent += "Success: " + currentSpell + Environment.NewLine;

        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont spriteFont, GraphicsDevice GraphicsDevice)
        {
            foreach (SpellCounter sc in spellFields)
            {
                sc.Draw(spriteBatch,GraphicsDevice);
            }

            spriteBatch.DrawString(spriteFont, debugContent, Vector2.Zero, Color.Turquoise);
        }
    }
}
