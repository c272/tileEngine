using DarkUI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tileEngine.SDK.Map;
using tileEngine.Utility;

namespace tileEngine.Controls.Properties
{
    /// <summary>
    /// Represents a window for editing the properties of a selected map event.
    /// </summary>
    public partial class EventPropertiesControl : PropertiesControl
    {
        /// <summary>
        /// The event that is being edited by this properties control.
        /// </summary>
        public TileEvent Event { get; private set; }

        //The document that is being modified by this event properties control.
        private MapEditorDocument document;

        public EventPropertiesControl(MapEditorDocument doc, Point tilePoint, TileEvent tileEvent) : base ($"Event at ({tilePoint.X}, {tilePoint.Y}) Properties")
        {
            InitializeComponent();
            Event = tileEvent;
            document = doc;

            //Pass in event data to data text box.
            dataText.Text = Event.Data;

            //Configure function name dropdown.
            foreach (var func in doc.EventFunctions)
            {
                functionDropdown.Items.Add(new DarkDropdownItem()
                {
                    Text = func
                });
            }

            //Configure trigger type dropdown.
            var triggerTypes = (EventTriggerType[])Enum.GetValues(typeof(EventTriggerType));
            foreach (var triggerType in triggerTypes)
            {
                triggerDropdown.Items.Add(new TaggedDropdownItem<object>()
                {
                    Text = Enum.GetName(typeof(EventTriggerType), triggerType),
                    Tag = triggerType
                });
            }

            //Set properties from current data.
            DarkDropdownItem toSelect = triggerDropdown.Items.Where(x => (EventTriggerType)((TaggedDropdownItem<object>)x).Tag == tileEvent.Trigger)
                                                             .FirstOrDefault();
            triggerDropdown.SelectedItem = toSelect;
            toSelect = functionDropdown.Items.Where(x => x.Text == tileEvent.LinkedFunction).FirstOrDefault();
            functionDropdown.SelectedItem = toSelect;

            //Link events.
            triggerDropdown.SelectedItemChanged += triggerChanged;
            functionDropdown.SelectedItemChanged += functionLinkChanged;
        }

        /// <summary>
        /// Triggered when the user changes the linked function in the properties menu.
        /// </summary>
        private void functionLinkChanged(object sender, EventArgs e)
        {
            if (functionDropdown.SelectedItem == null)
                return;
            Event.LinkedFunction = functionDropdown.SelectedItem.Text;
            document.Node.UnsavedChanges = true;
        }

        /// <summary>
        /// Triggered when the user changes the event function trigger in the properties menu.
        /// </summary>
        private void triggerChanged(object sender, EventArgs e)
        {
            if (triggerDropdown.SelectedItem == null)
                return;
            Event.Trigger = (EventTriggerType)((TaggedDropdownItem<object>)triggerDropdown.SelectedItem).Tag;
            document.Node.UnsavedChanges = true;
        }

        /// <summary>
        /// Triggered when the user changes the event data in the properties menu.
        /// </summary>
        private void dataTextChanged(object sender, EventArgs e)
        {
            Event.Data = dataText.Text;
            document.Node.UnsavedChanges = true;
        }
    }
}
