#include "stdafx.h"
#include <windows.h> 
#include <GL\glut.h>
#include <iostream>

char title[] = "3D_h250K_lab4";

GLfloat angle = 0.0f;
float first_k = 0;

struct cord
{
	float x1;
	float y1;
	float z1;

	float x2;
	float y2;
	float z2;
};
cord MyCord;

void initGL() {
	glClearColor(1.0f, 1.0f, 1.0f, 1.0f);
	glClearDepth(1.0f);
	glEnable(GL_DEPTH_TEST);
	glDepthFunc(GL_LEQUAL);
	glShadeModel(GL_SMOOTH);
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);
}

void math()
{
	MyCord.x1 = 3 * cos(angle);
	MyCord.z1 = 3 * sin(angle);

	MyCord.x2 = 3 * cos(angle + GLfloat(180));
	MyCord.z2 = 3 * sin(angle + GLfloat(180));

}

void display() {
	math();
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	glTranslatef(MyCord.x1, 0.0f, -10.0f + MyCord.z1);

	glColor3f(0.1, 0.8, 0.6);
	glRotatef(0.0f, 1.0f, 1.0f, 1.0f);
	GLUquadricObj* quad;
	quad = gluNewQuadric();
	gluSphere(quad, 1, 100, 20);


	

	glLoadIdentity();
	glTranslatef(MyCord.x2, 0.0f, -10.0f + MyCord.z2);

	glColor3f(0.05, 1.0, 0.45);
	glRotatef(63, 0.0f, 1.0f, 0.0f);
	glRotatef(-180 * (angle) / 3.141592653589793238462643383279f, 0.0f, 1.0f, 0.0f);
	GLUquadricObj* quadC;
	quadC = gluNewQuadric();
	gluCylinder(quadC, 0.5, 0.5, 5, 300, 20);
	
	glLoadIdentity();
	glTranslatef(MyCord.x2, 0.0f, -10.0f + MyCord.z2);

	glColor3f(0.1, 0.8, 0.6);
	glRotatef(0.0f, 1.0f, 1.0f, 1.0f);
	GLUquadricObj* quad2;
	quad2 = gluNewQuadric();
	gluSphere(quad2, 1, 100, 20);


	glutSwapBuffers();
}

float pers = 60;
void reshape(GLsizei width, GLsizei height) {

	if (height == 0) height = 1;
	height = 500;
	width = 1000;
	GLfloat aspect = (GLfloat)width / (GLfloat)height;

	glViewport(0, 0, width, height);

	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	gluPerspective(pers, aspect, 0.1f, 100.0f);
}

void processSpecialKeys(int key, int a, int b) {
	switch (key) {

	case GLUT_KEY_UP:
		pers--;
		reshape(1000, 500);
		display();
		break;
	case GLUT_KEY_DOWN:
		pers++;
		reshape(1000, 500);
		display();
		break;
	case GLUT_KEY_LEFT:
		angle = angle - first_k/100;
		display();
		break;
	case GLUT_KEY_RIGHT:
		angle = angle + first_k/100;
		display();
		break;

	}
};

int main(int argc, char** argv) {
	std::cin >> first_k;
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_DOUBLE);
	glutInitWindowSize(1000, 500);
	glutInitWindowPosition(50, 50);
	glutCreateWindow(title);
	glutDisplayFunc(display);
	glutReshapeFunc(reshape);
	initGL();
	glutSpecialFunc(processSpecialKeys);
	glutMainLoop();
	return 0;
}