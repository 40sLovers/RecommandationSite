from django.test import TestCase
from django.http import HttpResponse,HttpRequest

from . import views

class TestTestCase(TestCase):
    def setUp(self):
        #codul de aici este rulat intainte de test case-uri, il folosim in general pentru a initializa obiectele.
        pass

    def test_hello_world(self):
        req = HttpRequest()
        self.assertEqual(str(views.helloWorld(req)), str(HttpResponse("helloWorld")))
