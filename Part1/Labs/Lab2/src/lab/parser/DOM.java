package lab.parser;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import lab.struct.Plane;
import org.w3c.dom.Document;

public class DOM {
	private static Plane tempPlane;
	private static ArrayList<Plane> planeList = new ArrayList<>();
	
	public static void ParseDOM(Document doc)
	{
    doc.getDocumentElement().normalize();
    NodeList nList = doc.getElementsByTagName("Plane");
    
    for (int temp = 0; temp < nList.getLength(); temp++) {
        Node nNode = nList.item(temp);
        if (nNode.getNodeType() == Node.ELEMENT_NODE) {
           Element eElement = (Element) nNode;
           tempPlane = new Plane();

           tempPlane.set_model(eElement.getElementsByTagName("Model").item(0).getTextContent());
           tempPlane.set_origin(eElement.getElementsByTagName("Origin").item(0).getTextContent());
           tempPlane.set_chars_type(eElement.getElementsByTagName("Type").item(0).getTextContent());
           tempPlane.set_chars_nofseats(Byte.parseByte(eElement.getElementsByTagName("NumberOfSeats").item(0).getTextContent()));
           tempPlane.set_chars_am_availability(Boolean.parseBoolean(eElement.getElementsByTagName("Availability").item(0).getTextContent()));
           tempPlane.set_chars_am_count(Byte.parseByte(eElement.getElementsByTagName("Count").item(0).getTextContent()));
           tempPlane.set_chars_radar(Boolean.parseBoolean(eElement.getElementsByTagName("Radar").item(0).getTextContent()));
           tempPlane.set_param_lenght(Double.parseDouble(eElement.getElementsByTagName("Length").item(0).getTextContent()));
           tempPlane.set_param_height(Double.parseDouble(eElement.getElementsByTagName("Height").item(0).getTextContent()));
           tempPlane.set_param_width(Double.parseDouble(eElement.getElementsByTagName("Width").item(0).getTextContent()));
               
           tempPlane.set_price(Integer.parseInt(eElement.getElementsByTagName("Price").item(0).getTextContent()));
           planeList.add(tempPlane);
        }
     }
	}
	

	
	public static ArrayList<Plane> Run(String pathFile) throws IOException, SAXException, ParserConfigurationException
	{
		File inputFile = new File(pathFile);
        DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
        DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
        Document doc = dBuilder.parse(inputFile);
        ParseDOM(doc);
        return planeList;
    } 
}
