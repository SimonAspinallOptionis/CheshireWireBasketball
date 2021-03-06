﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website.CheshireWire.Models;

namespace Website.CheshireWire.Controllers
{
    public class GameController : Controller
    {
        private CheshireWireDataEntities db = new CheshireWireDataEntities();
        private List<Fixture> Fixtures = new List<Fixture>();
        private List<Result> ResultCollection = new List<Result>();

        #region Page Navigation

        public ActionResult Results()
        {
            ResultCollection = db.Results.ToList();

            ViewBag.Under13WhiteResults = db.Results.Where(r => r.Fixture.Team.Name == "White" && r.Fixture.Team.League.Name == "Under 13").ToList();

            //FillResults();
            return View();
        }

        private Fixture GetFixtureById(int fixtureId)
        {
            return db.Fixtures.ToList().First(f => f.Id == fixtureId);
        }

        //private Fixture GetFixtureById(int fixtureId)
        //{
        //    var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CheshireWireConnection"].ConnectionString);
        //    var cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = conn;

        //    var ds = new DataSet();

        //    try
        //    {
        //        cmd.CommandText = "usp_GetFixtureById";
        //        cmd.Parameters.Add(new SqlParameter("@id", fixtureId));
        //        cmd.Connection.Open();
        //        var da = new SqlDataAdapter(cmd);

        //        da.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (cmd.Connection.State == ConnectionState.Open)
        //        {
        //            cmd.Connection.Close();
        //        }
        //    }

        //    var fixture = ds.Tables[0].AsEnumerable()
        //        .Select(r => new Fixture
        //        {
        //            Id = r.Field<int>("Id"),
        //            OpponentName = r.Field<string>("OpponentName"),
        //            Organisation = r.Field<string>("Organisation"),
        //            TipOff = r.Field<DateTime>("TipOff"),
        //            AddressLine1 = r.Field<string>("AddressLine1"),
        //            AddressLine2 = r.Field<string>("AddressLine2"),
        //            TownCity = r.Field<string>("TownCity"),
        //            Postcode = r.Field<string>("Postcode"),
        //            TeamName = r.Field<string>("TeamName"),
        //            LeagueName = r.Field<string>("LeagueName"),
        //            TeamLogoUrl = r.Field<string>("ImgName")
        //        }).ToList()[0];

        //    return fixture;
        //}

        //public ActionResult GameDetails(int id)
        //{
        //    ResultCollection = new List<Result>();

        //    var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CheshireWireConnection"].ConnectionString);
        //    var cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = conn;

        //    var ds = GetResultsDataSet(cmd);

        //    MapOutResults(ds);

        //    var result = ResultCollection.First(r => r.Id == id);

        //    return View(result);
        //}

        //public ActionResult Schedule()
        //{
        //    Fixtures = new List<Fixture>();

        //    var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CheshireWireConnection"].ConnectionString);
        //    var cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Connection = conn;

        //    var ds = GetFixturesDataSet(cmd);

        //    MapOutFixtures(ds);

        //    FillFixtures();

        //    return View();
        //}

        #endregion

        #region Get Data Sets

        //private DataSet GetResultsDataSet(SqlCommand cmd)
        //{
        //    var ds = new DataSet();

        //    try
        //    {
        //        cmd.CommandText = "usp_GetResults";
        //        cmd.Connection.Open();
        //        var da = new SqlDataAdapter(cmd);

        //        da.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (cmd.Connection.State == ConnectionState.Open)
        //        {
        //            cmd.Connection.Close();
        //        }
        //    }

        //    return ds;
        //}


        //private DataSet GetFixturesDataSet(SqlCommand cmd)
        //{
        //    var ds = new DataSet();
        //    try
        //    {
        //        cmd.CommandText = "usp_GetFixtures";
        //        cmd.Connection.Open();
        //        var da = new SqlDataAdapter(cmd);

        //        da.Fill(ds);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (cmd.Connection.State == ConnectionState.Open)
        //        {
        //            cmd.Connection.Close();
        //        }
        //    }
        //    return ds;
        //}

        #endregion

    //    #region Mapping

    //    private void MapOutResults(DataSet ds)
    //    {
    //        ResultCollection.AddRange(ds.Tables[0].AsEnumerable()
    //            .Select(r => new Result
    //            {
    //                Id = r.Field<int>("Id"),
    //                CheshireScore = r.Field<int>("CheshireScore"),
    //                OpponentScore = r.Field<int>("OpponentScore"),
    //                Fixture = GetFixtureById(r.Field<int>("FixtureId")),
    //                GameStory = r.Field<string>("GameStory"),
    //                BoxScore = r.Field<string>("BoxScore"),
    //                ShotChartUrl = r.Field<string>("ShotChartUrl")
    //            }).ToList());
    //    }


    //    private void MapOutFixtures(DataSet ds)
    //    {
    //        Fixtures.AddRange(ds.Tables[0].AsEnumerable()
    //            .Select(r => new Fixture
    //            {
    //                Id = r.Field<int>("Id"),
    //                OpponentName = r.Field<string>("OpponentName"),
    //                Organisation = r.Field<string>("Organisation"),
    //                TipOff = r.Field<DateTime>("TipOff"),
    //                AddressLine1 = r.Field<string>("AddressLine1"),
    //                AddressLine2 = r.Field<string>("AddressLine2"),
    //                TownCity = r.Field<string>("TownCity"),
    //                Postcode = r.Field<string>("Postcode"),
    //                TeamName = r.Field<string>("TeamName"),
    //                LeagueName = r.Field<string>("LeagueName"),
    //                TeamLogoUrl = r.Field<string>("ImgName")
    //            }).ToList());
    //    }

    //    #endregion

    //    #region Fill

    //    private void FillResults()
    //    {
    //        ViewBag.Under13WhiteResults = ResultCollection.Where(r =>  TeamName == "White" && r.Fixture.LeagueName == "Under 13").OrderByDescending(r => r.Fixture.TipOff).ToList();
    //        ViewBag.Under13GreenResults = ResultCollection.Where(r => r.Fixture.TeamName == "Green" && r.Fixture.LeagueName == "Under 13").OrderByDescending(r => r.Fixture.TipOff).ToList();
    //        ViewBag.Under14Results = ResultCollection.Where(r => r.Fixture.LeagueName == "Under 14").OrderByDescending(r => r.Fixture.TipOff).ToList();
    //        ViewBag.Under15Results = ResultCollection.Where(r => r.Fixture.LeagueName == "Under 15").OrderByDescending(r => r.Fixture.TipOff).ToList();
    //        ViewBag.Under16CResults = ResultCollection.Where(r => r.Fixture.TeamName == "Conference" && r.Fixture.LeagueName == "Under 16").OrderByDescending(r => r.Fixture.TipOff).ToList();
    //        ViewBag.Under16PResults = ResultCollection.Where(r => r.Fixture.TeamName == "Premier" && r.Fixture.LeagueName == "Under 16").OrderByDescending(r => r.Fixture.TipOff).ToList();
    //        ViewBag.Under18CResults = ResultCollection.Where(r => r.Fixture.TeamName == "Conference" && r.Fixture.LeagueName == "Under 18").OrderByDescending(r => r.Fixture.TipOff).ToList();
    //        ViewBag.Under18PResults = ResultCollection.Where(r => r.Fixture.TeamName == "Premier" && r.Fixture.LeagueName == "Under 18").OrderByDescending(r => r.Fixture.TipOff).ToList();
    //    }


    //    private void FillFixtures()
    //    {
    //        ViewBag.Under13WhiteSchedule = Fixtures.Where(f => f.TeamName == "White" && f.LeagueName == "Under 13");
    //        ViewBag.Under13GreenSchedule = Fixtures.Where(f => f.TeamName == "Green" && f.LeagueName == "Under 13");
    //        ViewBag.Under14Schedule = Fixtures.Where(f => f.LeagueName == "Under 14");
    //        ViewBag.Under15Schedule = Fixtures.Where(f => f.LeagueName == "Under 15");
    //        ViewBag.Under16CSchedule = Fixtures.Where(f => f.TeamName == "Conference" && f.LeagueName == "Under 16");
    //        ViewBag.Under16PSchedule = Fixtures.Where(f => f.TeamName == "Premier" && f.LeagueName == "Under 16");
    //        ViewBag.Under18CSchedule = Fixtures.Where(f => f.TeamName == "Conference" && f.LeagueName == "Under 18");
    //        ViewBag.Under18PSchedule = Fixtures.Where(f => f.TeamName == "Premier" && f.LeagueName == "Under 18");

    //    }

    //    #endregion
    }
}