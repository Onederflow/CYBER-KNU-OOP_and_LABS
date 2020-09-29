package lab.parser;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

import javax.xml.XMLConstants;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import javax.xml.transform.Source;
import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import javax.xml.validation.Validator;

import org.xml.sax.SAXException;
import lab.struct.Plane;

import lab.parser.XMLErrors;
import lab.parser.XMLReader;

public class SAX {
	private static ArrayList<Plane> planeList = new ArrayList<>();
	public static ArrayList<Plane> Run(String pathFile) throws IOException, SAXException, ParserConfigurationException
	{
		// Create a "parser factory" for creating SAX parsers
		SAXParserFactory spfac = SAXParserFactory.newInstance();
		Source xmlFile = new StreamSource(new File(pathFile));
		SchemaFactory schemaFactory = SchemaFactory.newInstance(XMLConstants.W3C_XML_SCHEMA_NS_URI);
		Schema schema = schemaFactory.newSchema(new File("DataToParsing/Plane.xsd"));
		Validator validator = schema.newValidator();
		validator.setErrorHandler(new XMLErrors());
		try {
			validator.validate(xmlFile);
			// Now use the parser factory to create a SAXParser object
			SAXParser sp = spfac.newSAXParser();
			// Create an instance of this class
			XMLReader reader = new XMLReader();
			// Finally, tell the parser to parse the input and notify the handler
			sp.parse("DataToParsing/Plane.xml", reader);
			planeList = reader.getList();
			} catch (SAXException e) {
			System.out.println(xmlFile.getSystemId() + " is NOT valid");
		}	
		return planeList;
	}
}
