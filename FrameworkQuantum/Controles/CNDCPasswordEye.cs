using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Controles
    {
    
    // ********************************************* class PasswordEye
    
    public partial class CNDCPasswordEye : UserControl
        {

        // ******************************** control delegate and event
        
        public delegate void PasswordEyePropertiesChangedHandler ( 
                        Object                                sender,
                        PasswordEyePropertiesChangedEventArgs e );
                                        
        public event PasswordEyePropertiesChangedHandler 
                            PasswordEyePropertiesChanged;

        // ************************************************* Constants
        
        static Color    BACKCOLOR = Color.White;
        static Color    FORECOLOR = Color.Black;
                                        // used to specify whether or 
                                        // not TextBox Text is masked
        const char      PASSWORD_HIDDEN = '*';
        const char      PASSWORD_VISIBLE = '\0';
                                        // initial TextBox properties
        const int       TEXTBOX_HEIGHT = 15;
        const int       TEXTBOX_LOCATION_X = 1;
        const int       TEXTBOX_LOCATION_Y = 1;
        static int      TEXTBOX_MAXIMUM_WIDTH = 10;
        const int       TEXTBOX_MAXLENGTH = 50;
                                        // initial Button properties
        const int       BUTTON_HEIGHT = TEXTBOX_HEIGHT;
        const int       BUTTON_WIDTH = BUTTON_HEIGHT;
                                        // initial panel properties
        const int       PANEL_LOCATION_X = 1;
        const int       PANEL_LOCATION_Y = 1;
        const string    WIDEST_CHARACTER = "W";
        
        // ************************************************* variables
        
        Color           backcolor = BACKCOLOR;
        Color           forecolor = FORECOLOR;
        int             textbox_maximum_width = TEXTBOX_MAXIMUM_WIDTH;

        // ************** trigger_passwordeye_properties_changed_event

        void trigger_passwordeye_properties_changed_event ( )
            {

            if ( PasswordEyePropertiesChanged != null )
                {
                PasswordEyePropertiesChanged ( 
                    this,
                    new PasswordEyePropertiesChangedEventArgs (
                                                backcolor,
                                                button,
                                                this,
                                                forecolor,
                                                textbox_maximum_width,
                                                panel,
                                                textbox ) );
                }
            }

        // **************************************** textbox_text_width
        
        int textbox_text_width ( )
            {
            string  textbox_text = String.Empty;
            int     width = 0;
                                        // build a test string so we 
                                        // can find the width needed 
                                        // for the textbox
            while ( textbox_text.Length < textbox_maximum_width )
                {
                textbox_text += WIDEST_CHARACTER;
                }
                
            using ( Graphics graphics = textbox.CreateGraphics ( ) )
			    {
				Size    size = TextRenderer.MeasureText (
	                                graphics, 
	                                textbox_text, 
	                                textbox.Font, 
	                                new Size ( 1, 1 ), 
	                                TextFormatFlags.NoPadding );
                                        // MeasureText does not appear 
                                        // to return a correct length; 
                                        // 2/3 seems to help
				width = 
				    round ( ( 2.0 * ( double ) size.Width ) / 3.0 );
			    }

            return ( width );
            }
            
        // *********************************************** PasswordEye

        public CNDCPasswordEye()
            {

            InitializeComponent ( );
            
            button.MouseDown += new MouseEventHandler (
                                                button_MouseDown );
            button.MouseUp += new MouseEventHandler ( 
                                                button_MouseUp );
            textbox.FontChanged += new EventHandler ( 
                                                textbox_FontChanged );
            textbox.TextChanged += new EventHandler ( 
                                                textbox_TextChanged );
            }

        // **************************************************** OnLoad
        
        protected override void OnLoad ( EventArgs e )
            {
            
            base.OnLoad ( e );
            
            set_control_properties ( );
            }

        // ***************************************************** round
        
        // http://en.wikipedia.org/wiki/Rounding
        
        int round ( double double_value )
            {
            
            return ( ( int ) ( double_value + 0.5 ) );
            }

        // ************************************ set_control_properties

        void set_control_properties ( )
            {
            int button_location_y = 0;
                                        // remove all components from 
                                        // the control
            this.Controls.Clear ( );
                                        // remove all components from 
                                        // the panel
            panel.Controls.Clear ( );
                                        // process textbox first; the 
                                        // textbox width is dependent 
                                        // on the Font and the 
                                        // Max_Display properties; in
                                        // turn the textbox properties 
                                        // drive most of the control's 
                                        // other properties
            textbox.BackColor = backcolor;
            textbox.BorderStyle = BorderStyle.None;
            textbox.ForeColor = forecolor;
                                        // textbox location within 
                                        // panel is fixed 
            textbox.Location = new Point ( TEXTBOX_LOCATION_X,
                                           TEXTBOX_LOCATION_Y );
            textbox.Size = new Size ( textbox_text_width ( ), 
                                      textbox.Height );
                                        // process button next; the 
                                        // panel width depends upon 
                                        // both the textbox and button 
                                        // properties
            button.BackColor = backcolor;
            button.BackgroundImage = Properties.Resources.PasswordEyeImage;
            button.BackgroundImageLayout = ImageLayout.Zoom;
            button.FlatStyle = FlatStyle.Flat;
                                        // when the textbox.Height is 
                                        // greater than TEXTBOX_HEIGHT 
                                        // the button.Size takes on 
                                        // the value 
                                        //      ( BUTTON_HEIGHT, 
                                        //        BUTTON_WIDTH ) 
                                        // and the button is centered 
                                        // vertically with respect to 
                                        // the textbox
            if ( textbox.Height > TEXTBOX_HEIGHT )
                {
                button.Size = new Size ( BUTTON_HEIGHT, 
                                         BUTTON_WIDTH );
                button_location_y = 
                    round ( ( double ) ( textbox.Height - 
                                         button.Height ) / 2.0 );
                }
            else
                {
                button.Size = new Size ( textbox.Height, 
                                         textbox.Height );
                button_location_y = textbox.Location.Y;
                }
            button.Location = new Point ( textbox.Location.X +
                                              textbox.Width + 1,
                                          button_location_y );
                                        // process panel
            panel.BackColor = backcolor;
                                        // panel location within 
                                        // control is fixed
            panel.Location = new Point ( PANEL_LOCATION_X, 
                                         PANEL_LOCATION_Y );
            panel.Size = new Size ( 
                                        // space preceeds textbox
                                    ( textbox.Location.X + 1 ) +
                                        // space follows textbox
                                        ( textbox.Width + 1 ) +
                                        // space follows button
                                        ( button.Width + 1 ),
                                        // space at top and bottom
                                    ( textbox.Height + 2 ) );
                                        // add back the TextBox and 
                                        // the Button to the Panel's 
                                        // control collection
            panel.Controls.Add ( textbox );
            panel.Controls.Add ( button );
                                        // add back the Panel to the 
                                        // control's control 
                                        // collection
            this.Controls.Add ( panel );
                                        // adjust the width and height 
                                        // of the control by adding a 
                                        // pixel at the right, left,
                                        // top, and bottom
            this.Width = panel.Width + 2;
            this.Height = panel.Height + 2;
                                        // advise any subscriber that 
                                        // the control properties have 
                                        // changed
            trigger_passwordeye_properties_changed_event ( );
            }

        // ****************************************** button_MouseDown

        void button_MouseDown ( object         sender, 
                                MouseEventArgs e )
            {

            base.OnMouseDown ( e );

            textbox.PasswordChar = PASSWORD_VISIBLE;
            }

        // ******************************************** button_MouseUp

        void button_MouseUp ( object         sender, 
                              MouseEventArgs e )
            {

            base.OnMouseUp ( e );

            textbox.PasswordChar = PASSWORD_HIDDEN;
            }

        // *************************************** textbox_FontChanged
        
        void textbox_FontChanged ( object    sender, 
                                   EventArgs e )
            {

            base.OnFontChanged ( e );
            
            set_control_properties ( );
            }

        // *************************************** textbox_TextChanged

        void textbox_TextChanged ( object    sender, 
                                   EventArgs e )
            {

            base.OnTextChanged ( e );

            trigger_passwordeye_properties_changed_event ( );
            }

        // ************************************************* BackColor
        
        [Category ( "Appearance" ),
         Description ( "Gets/Sets backcolor of all components" ),
         DefaultValue ( typeof ( Color ), "White" ),
         Bindable ( true )]
        public override Color BackColor
            {
            
            get
                {
                return ( backcolor );
                }
            set
                {
                if ( value != backcolor )
                    {
                    backcolor = value;
                    set_control_properties ( );
                    }
                }
            }
                
        // ****************************************************** Font

        [Category ( "Appearance" ),
         Description ( "Gets/Sets the password textbox font" ),
         Bindable ( true )]
        public override Font Font
            {
            get
                {
                return ( textbox.Font );
                }
            set
                {
                if ( value != textbox.Font )
                    {
                                        // textbox_FontChanged is 
                                        // triggered by the following 
                                        // statement
                    textbox.Font = value;
                    }
                }
            }

        // ************************************************* ForeColor
        
        [Category ( "Appearance" ),
         Description ( "Gets/Sets forecolor of all components" ),
         DefaultValue ( typeof ( Color ), "Black" ),
         Bindable ( true )]
        public override Color ForeColor
            {
            
            get
                {
                return ( forecolor );
                }
            set
                {
                if ( value != forecolor )
                    {
                    forecolor = value;
                    set_control_properties ( );
                    }
                }
            }

        // ********************************************* Maximum_Width
        
        [Category ( "Appearance" ),
         Description ( "Gets/Sets the width of the password textbox" ),
         DefaultValue ( 20 ),
         Bindable ( true )]
        public int Maximum_Width
            {
            
            get
                {
                return ( textbox_maximum_width );
                }
            set
                {
                if ( value != textbox_maximum_width )
                    {
                    textbox_maximum_width = value;
                    set_control_properties ( );
                    }
                }
            }                

        // ************************************************* MaxLength
        
        [Category ( "Appearance" ),
         Description ( "Gets/Sets password textbox MaxLength" ),
         DefaultValue ( 50 ),
         Bindable ( true )]
        public int MaxLength
            {
            
            get
                {
                return ( textbox.MaxLength );
                }
            set
                {
                if ( value != textbox.MaxLength )
                    {
                    textbox.MaxLength = value;
                    trigger_passwordeye_properties_changed_event ( );
                    }
                }
            }                

        // ********************************************** PasswordChar
        
        [Category ( "Appearance" ),
         Description ( "Gets/Sets password textbox PasswordChar" ),
         DefaultValue ( typeof ( char ), "*" ),
         Bindable ( true )]
        public char PasswordChar
            {

            get
                {
                return ( textbox.PasswordChar );
                }
            set
                {
                if ( textbox.PasswordChar != value )
                    {
                    textbox.PasswordChar = value;
                    set_control_properties ( );
                    }
                }
            }
            
        // ****************************************************** Text

        // http://stackoverflow.com/questions/2881409/
        //     text-property-in-a-usercontrol-in-c-sharp
        
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [Category ( "Appearance" )]
        [Description ( "Gets/Sets password textbox Text" )]
        [DefaultValue ( "" )]
        public override string Text
            {
            
            get
                {
                return ( textbox.Text );
                }
            set
                {
                if ( value != textbox.Text )
                    {
                    textbox.Text = value;
                    set_control_properties ( );
                    }
                }
            }

        } // class PasswordEye

    // ******************* class PasswordEyePropertiesChangedEventArgs

    public class PasswordEyePropertiesChangedEventArgs
        {
        public Color   backcolor;
        public Button  button;
        public Control control;
        public Color   forecolor;
        public int     maximum_width;
        public Panel   panel;
        public TextBox textbox;

        // ********************* PasswordEyePropertiesChangedEventArgs

        public PasswordEyePropertiesChangedEventArgs ( 
                                                Color   backcolor,
                                                Button  button,
                                                Control control,
                                                Color   forecolor,
                                                int     maximum_width,
                                                Panel   panel,
                                                TextBox textbox )
            {

            this.backcolor = backcolor;
            this.button = button;
            this.control = control;
            this.forecolor = forecolor;
            this.maximum_width = maximum_width;
            this.panel = panel;
            this.textbox = textbox;
            }

        } // class PasswordEyePropertiesChangedEventArgs
        
    } // namespace WinForms
