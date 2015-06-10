using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TouchScreenTest
{
    class SpellCounter
    {
        Texture2D notSelectedTexture, selectedTexture; 
        Vector2 location;
        SpellCounterState spellState;
        List<SpellCounter> connectors;
        public int id;
        
        /// <summary>
        /// Constructor
        /// Intializes this objects
        /// </summary>
        /// <param name="notSelectedTexture">--TEMP set non selected texture</param>
        /// <param name="selectedTexture">--TEMP set selected texture</param>
        /// <param name="location">Set initial position</param>
        /// <param name="id">Set this items identifier</param>
        // ---------TODO set the identifier to be a uniqueidentifier and dynamically load textures
        public SpellCounter(Texture2D notSelectedTexture, Texture2D selectedTexture,Vector2 location, int id)
        {
            this.id = id;
            this.notSelectedTexture = notSelectedTexture;
            this.selectedTexture = selectedTexture;
            this.location = location;
            connectors = new List<SpellCounter>();
            spellState = SpellCounterState.NotSelected;
        }
        public void UpdateState(SpellCounterState spellState)
        {
            this.spellState = spellState;
        }

        /// <summary>
        /// Checks to see if the given point exists inside of the 
        /// current collision box. 
        /// </summary>
        /// <param name="checkPoint"></param>
        /// <returns></returns>
        public bool isInside(Vector2 checkPoint)
        {
            float distanceBetween = Vector2.Distance(this.location,checkPoint);

            return distanceBetween < (notSelectedTexture.Width/2);
            
        }
        
        public void Draw(SpriteBatch spriteBatch, GraphicsDevice GraphicsDevice)
        {
            switch (spellState)
            {
                case SpellCounterState.Empty:
                    //break;
                case SpellCounterState.NotSelected:
                    spriteBatch.Draw(notSelectedTexture, location - new Vector2(notSelectedTexture.Width / 2, notSelectedTexture.Height / 2), Color.White);
        
                    break;
                case SpellCounterState.Selected:
                    spriteBatch.Draw(selectedTexture, location - new Vector2(selectedTexture.Width / 2, selectedTexture.Height / 2), Color.White);
        
                    break;
            }

            foreach (SpellCounter connector in connectors)
            {
                Shapes.DrawLine(spriteBatch, location ,
                                            connector.location , 2, Color.LightBlue, GraphicsDevice);
            }                
        }
        
        /// <summary>
        /// Adds the lines between 2 spell counters only if
        /// the connection does not already exist.
        /// </summary>
        /// <param name="spellCounter">Destination Counter</param>
        internal void AddConnector(SpellCounter spellCounter)
        {
            bool addCounter = true;

  
            foreach (SpellCounter counter in connectors) {
                addCounter &= counter.id != spellCounter.id;
            }

            if(addCounter)
            connectors.Add(spellCounter);
        }

        internal List<SpellCounter> GetConnectors()
        {
            return connectors;
        }
        internal void ClearConnectors()
        {
            connectors.Clear();
        }
    }
}
