using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator;

public partial class MainPage : ContentPage
{
	Calculator c = new Calculator() { Curr="0",Total="0",IsInit=true,PrepOp="" };
	public MainPage()
	{
		InitializeComponent();
		
		BindingContext =c;
		
	}

    private void Button_Number_Clicked(object sender, EventArgs e)
    {
		Button d= (Button)sender;
		decimal newValue=Convert.ToDecimal(d.Text);
		if (!c.IsInit)
		{
			newValue +=Convert.ToDecimal(c.Curr)*10;
		}
		c.Curr=newValue.ToString();
		c.IsInit=false;

    }

    private void Button_Clear_Clicked(object sender, EventArgs e)
    {
		c.Curr="0";
		c.Total="0";
		c.IsInit=true;
		c.PrepOp="";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Button b=(Button) sender;
		decimal result= Convert.ToDecimal(c.Total);
		switch(c.PrepOp){
			case "+":
				result+=Convert.ToDecimal(c.Curr);
				break;
			case "-":
				result-=Convert.ToDecimal(c.Curr);
				break;
			case "*":
				result*=Convert.ToDecimal(c.Curr);
				break;
			case "/":
				result/=Convert.ToDecimal(c.Curr);
				break;
			default:
				result=Convert.ToDecimal(c.Curr);
				break;
		}
		c.Curr= result.ToString();
		c.Total= result.ToString();
		c.IsInit= true;
		c.PrepOp= b.Text;
    }
}
public class Calculator:INotifyPropertyChanged{
	public event PropertyChangedEventHandler PropertyChanged;
	public void OnPropertyChanged(string name)=>
		PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
    private string curr;
	private string total;
	private bool isInit;
	private string prepOp;
	public string Curr{
		get=>curr;
		set{
			if (curr==value) 
				return;
			curr=value;
			OnPropertyChanged(nameof(Curr));
			//setCurr(value);
		}
	}
	public string Total{
		get=>total;
		set{
			if (total==value) return;
			total=value;
			OnPropertyChanged(nameof(Total));
		}
	}
	public bool IsInit{
		get=>isInit;
		set{
			if (isInit==value) return;
			isInit=value;
			OnPropertyChanged(nameof(IsInit));
		}
	}
	public string PrepOp{
		get=>prepOp;
		set{
			if (prepOp==value) return;
			prepOp=value;
			OnPropertyChanged(nameof(PrepOp));
		}
	}
}

