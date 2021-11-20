from django.test import TestCase
from RecommendationSite.backend.api.views import helloWorld

# Create your tests here.



class TestTestCase(TestCase):
    def setUp(self):
        pass
    def test_hello_world(self):
        self.assertEqual(helloWorld(), HttpResponse("helloWorld"))