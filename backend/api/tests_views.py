from django.test import TestCase
from django.http import HttpResponse,HttpRequest

from . import views

class AnimalTestCase(TestCase):
    def setUp(self):
        #codul de aici este rulat intainte de test case-uri, il folosim in general pentru a initializa obiectele.
        pass

    def test_helloWorld(self):
        req = HttpRequest()
        self.assertEqual(views.helloWorld(req).content,HttpResponse("helloWorld").content)
