from django.test import TestCase
from django.http import HttpResponse,HttpRequest

from . import views
# Create your tests here.



class TestTestCase(TestCase):
    def setUp(self):
        #aici initializam obiectele daca e cazul
        pass

    def test_hello_world(self):
        req = HttpRequest()
        self.assertEqual(str(views.helloWorld(req)), str(HttpResponse("helloWorld")))