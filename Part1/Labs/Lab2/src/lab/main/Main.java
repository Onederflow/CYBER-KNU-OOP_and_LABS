package lab.main;

import java.io.IOException;
import java.util.ArrayList;

import javax.xml.parsers.ParserConfigurationException;
import org.xml.sax.SAXException;

import lab.struct.Plane;
import lab.parser.DOM;
import lab.parser.SAX;

public class Main {

	static String pathFile = "DataToParsing/Plane.xml";

	//Print all
	public static void displayList(ArrayList<Plane> planeList){
		System.out.println("Count: " + planeList.size());
		for(Plane temp:planeList){
			System.out.println(temp);
		}
	}
	
	//Launching
	public static void main(String[] args) throws IOException, SAXException,
	ParserConfigurationException {
		System.out.println("DOM parser ->>>>>>\n-------------------------------------------------------------\n");
		displayList(DOM.Run(pathFile));
		System.out.println("-------------------------------------------------------------\n\n");
		System.out.println("SAX parser ->>>>>>\n-------------------------------------------------------------\n");
		displayList(SAX.Run(pathFile));
		System.out.println("-------------------------------------------------------------");
	}
}
