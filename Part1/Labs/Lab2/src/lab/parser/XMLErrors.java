package lab.parser;

import org.xml.sax.ErrorHandler;
import org.xml.sax.SAXException;
import org.xml.sax.SAXParseException;

public class XMLErrors implements ErrorHandler {
	public void warning(SAXParseException e) throws SAXException {
		System.out.println("WARNING: " + e.getMessage()); // do nothing
	}

	public void error(SAXParseException e) throws SAXException {
		System.out.println("ERROR : " + e.getMessage());
		throw e;
	}

	public void fatalError(SAXParseException e) throws SAXException {
		System.out.println("FATAL : " + e.getMessage());
		throw e;
	}
}
