package lab.struct;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Plane {
	//All variables
	private String model;
	private String origin;
	private String chars_type;
	private Byte chars_nofseats;
	private Boolean chars_am_availability;
	private Byte chars_am_count;
	private Boolean chars_radar;
	private Double param_lenght;
	private Double param_height;
	private Double param_width;
	private Integer price;

	
	public void set_model(String model)
	{
		this.model = model;
	}
	public String get_model()
	{
		return model;
	}
	
	public void set_origin(String origin)
	{
		this.origin = origin;
	}
	public String get_origin()
	{
		return origin;
	}
	
	public void set_chars_type(String chars_type)
	{
		this.chars_type = chars_type;
	}
	public String get_chars_type()
	{
		return chars_type;
	}

	public void set_chars_nofseats(Byte chars_nofseats)
	{
		this.chars_nofseats = chars_nofseats;
	}
	public Byte get_chars_nofseats()
	{
		return chars_nofseats;
	}

	public void set_chars_am_availability(Boolean chars_am_availability)
	{
		this.chars_am_availability = chars_am_availability;
	}
	public Boolean get_chars_am_availability()
	{
		return chars_am_availability;
	}

	public void set_chars_am_count(Byte chars_am_count)
	{
		this.chars_am_count = chars_am_count;
	}
	public Byte get_chars_am_count()
	{
		return chars_am_count;
	}

	public void set_chars_radar(Boolean chars_radar)
	{
		this.chars_radar = chars_radar;
	}
	public Boolean get_chars_radar()
	{
		return chars_radar;
	}

	public void set_param_lenght(Double param_lenght)
	{
		this.param_lenght = param_lenght;
	}
	public Double get_param_lenght()
	{
		return param_lenght;
	}
	
	public void set_param_height(Double param_height)
	{
		this.param_height = param_height;
	}
	public Double get_param_height()
	{
		return param_height;
	}

	public void set_param_width(Double param_width)
	{
		this.param_width = param_width;
	}
	public Double get_param_width()
	{
		return param_width;
	}

	public void set_price(Integer price)
	{
		this.price = price;
	}
	public Integer get_price()
	{
		return price;
	}

	
	//new element
	public Plane(String model, String origin, String chars_type, Byte chars_nofseats, 
			Boolean chars_am_availability, Byte chars_am_count, Boolean chars_radar, 
			Double param_lenght, Double param_height, Double param_width, int price) {
		this.model = model;
		this.origin = origin;
		this.chars_type = chars_type;
		this.chars_nofseats = chars_nofseats;
		this.chars_am_availability = chars_am_availability;
		this.chars_am_count = chars_am_count;
		this.chars_radar = chars_radar;
		this.param_lenght = param_lenght;
		this.param_height = param_height;
		this.param_width = param_width;
		this.price = price;
	}
	
	public Plane() {
		// TODO Auto-generated constructor stub
	}
	@Override
	public String toString() {
		//for changing the date format i.e. trimming the time attribute.
		String res = "Plane "
				+ "\n	Model : " + model
				+ "\n	Origin  : " + origin
				+ "\n	Type : " + chars_type
				+ "\n	Number of seats : " + chars_nofseats
				+ "\n	Ammunition : " + chars_am_availability;
		if(chars_am_availability != null && chars_am_availability == true)
			res += "\n	Count of Ammunition : " + chars_am_count;
		res += "\n	Radar : " + chars_radar 
				+ "\n	Parameters (L,W,H) : " + param_lenght + " " + param_width + " " + param_height 
				+ "\n	Price : " + price;		
		return res;
	}	
}
