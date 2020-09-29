package lab.parser;
import java.util.ArrayList;

import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import lab.struct.Plane;

public class XMLReader extends DefaultHandler {
	//Temp for using parser
	private String temp;
	private Plane tempPlane;
	private static ArrayList<Plane> planeList = new ArrayList<>();
	
	public void characters(char ch[], int start, int length)
			throws SAXException {
		temp = new String(ch, start, length);
	}
	
	//Realy? Element is true>>>
	public void startElement(String uri, String localName, String qName,
			Attributes attributes) throws SAXException {
		temp = "";
		if (qName.equalsIgnoreCase("Plane")) {
			tempPlane = new Plane();
		}
	}
	
	//Just parse IT!
	public void endElement(String uri, String localName, String qName)
			throws SAXException {
		
		if(qName.equalsIgnoreCase("Plane")){
			// add it to the list
			planeList .add(tempPlane);
		}else if(qName.equalsIgnoreCase("Model")){
			tempPlane.set_model(temp);
		}else if(qName.equalsIgnoreCase("Origin")){
		tempPlane.set_origin(temp);
		}else if(qName.equalsIgnoreCase("Type")){
			tempPlane.set_chars_type(temp);		
		}else if(qName.equalsIgnoreCase("NumberOfSeats")){
				tempPlane.set_chars_nofseats(Byte.parseByte(temp));
		}else if(qName.equalsIgnoreCase("Availability")){
			tempPlane.set_chars_am_availability(Boolean.parseBoolean(temp));		
		}else if(qName.equalsIgnoreCase("Count")){
			tempPlane.set_chars_am_count(Byte.parseByte(temp));
		}else if(qName.equalsIgnoreCase("Radar")){
			tempPlane.set_chars_radar(Boolean.parseBoolean(temp));	
		}else if(qName.equalsIgnoreCase("Length")){
			tempPlane.set_param_lenght(Double.parseDouble(temp));	
		}else if(qName.equalsIgnoreCase("Height")){
			tempPlane.set_param_height(Double.parseDouble(temp));	
		}else if(qName.equalsIgnoreCase("Width")){
			tempPlane.set_param_width(Double.parseDouble(temp));
		}else if(qName.equalsIgnoreCase("Price")){
			tempPlane.set_price(Integer.parseInt(temp));};
	}
	
	//back
	public ArrayList<Plane> getList(){
		return planeList;
	}
}
