﻿using AdvisoryDatabase.Business.Service;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Task = System.Threading.Tasks.Task;

namespace AdvisoryDatabase.Business.Controllers
{
    public class CourseController : BaseController
    {
        public APIResponse<Course> GetCourse(Course course)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                return SuccessReponse(service.GetAll(course).SingleOrDefault());
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<Course>(error);
            }

        }
        public APIResponse<List<Course>> GetAllCourse()
        {
            try
            {
                CourseDataService service = new CourseDataService();
                return SuccessReponse(service.GetAll());
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<List<Course>>(error);
            }
        }
        public APIResponse<Course> InsertCourse(Course course)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                course.CurrentData = ToXML(course);
                course.CourseMasterID = service.Add(course);
                SaveUpdateSkillMasterIDs(course);
                SaveUpdateIndustries(course);
                SaveUpdateAudienceLevels(course);
                SaveUpdateFOSService(course);
                SaveUpdateSGSLSNFormGroups(course);
                SaveUpdateEquivalentCourseIDService(course);
                SaveUpdatePrerequisiteCourseIDService(course);
                SaveUpdateaudienceTypeService(course);
                SaveUpdateCourseFunctionService(course);
                SaveUpdateCourseOwnerService(course);
                return SuccessReponse(course);
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<Course>(error);
            }
        }
        public APIResponse<Course> UpdateCourse(Course course)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                course.CurrentData = ToXML(course);
                course.PreviousData = ToXML(service.GetAll(course).SingleOrDefault());
                service.Update(course);
                SaveUpdateSkillMasterIDs(course);
                SaveUpdateIndustries(course);
                SaveUpdateAudienceLevels(course);
                SaveUpdateFOSService(course);
                SaveUpdateSGSLSNFormGroups(course);
                SaveUpdateEquivalentCourseIDService(course);
                SaveUpdatePrerequisiteCourseIDService(course);
                SaveUpdateaudienceTypeService(course);
                SaveUpdateCourseFunctionService(course);
                SaveUpdateCourseOwnerService(course);
                return SuccessReponse(course);
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<Course>(error);
            }
        }

        public string ToXML(Object oObject)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlSerializer xmlSerializer = new XmlSerializer(oObject.GetType());
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, oObject);
                xmlStream.Position = 0;
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

        private async Task SaveUpdateSkillMasterIDs(Course course)
        {
            await Task.Run(() =>
            {
                CourseSkillMappingService SkillService = new CourseSkillMappingService();
                if (course.SkillMasterIDs != null && course.SkillMasterIDs.Any())
                {
                    SkillService.Remove(course.CourseMasterID);
                    foreach (var item in course.SkillMasterIDs)
                    {
                        if (item !=null && item?.Id != 0)
                        {
                            CourseSkillMapping courseSkillMapping = new CourseSkillMapping();
                            courseSkillMapping.CourseMasterID = course.CourseMasterID;
                            courseSkillMapping.SkillMasterID = (int)item.Id;
                            SkillService.Add(courseSkillMapping);
                        }
                    }
                }
            });
        }
        private async Task SaveUpdateIndustries(Course course)
        {
            await Task.Run(() =>
            {
                CourseIndustryMappingService IndustryService = new CourseIndustryMappingService();
                if (course.Industries != null && course.Industries.Any())
                {
                    IndustryService.Remove(course.CourseMasterID);
                    foreach (var item in course.Industries)
                    {
                        if (item != null && item?.Id != 0)
                        {
                            CourseIndustryMapping courseIndustryMapping = new CourseIndustryMapping();
                            courseIndustryMapping.CourseMasterID = course.CourseMasterID;
                            courseIndustryMapping.IndustryID = (int)item.Id;
                            IndustryService.Add(courseIndustryMapping);
                        }
                    }
                }
            });
        }
        private async Task SaveUpdateAudienceLevels(Course course)
        {
            await Task.Run(() =>
            {
                AudienceLevelMappingService audienceLevelService = new AudienceLevelMappingService();
                if (course.AudienceLevels != null && course.AudienceLevels.Any())
                {
                    audienceLevelService.Remove(course.CourseMasterID);
                    foreach (var item in course.AudienceLevels)
                    {
                        if (item !=null && item?.Id != 0)
                        {
                            AudienceLevelMapping audienceLevelMapping = new AudienceLevelMapping();
                            audienceLevelMapping.CourseMasterID = course.CourseMasterID;
                            audienceLevelMapping.AudienceLevelId = (int)item.Id;
                            audienceLevelService.Add(audienceLevelMapping);
                        }
                    }
                }
            });
        }
        private async Task SaveUpdateFOSService(Course course)
        {
            await Task.Run(() =>
            {
                CourseFieldOfStudyMappingService FOSService = new CourseFieldOfStudyMappingService();
                if (course.FieldOfStudyFormGroup != null && course.FieldOfStudyFormGroup.Any())
                {
                    FOSService.Remove(course.CourseMasterID);
                    foreach (var item in course.FieldOfStudyFormGroup)
                    {
                        if (item.FieldOfStudy !=null && item.FieldOfStudy?.Id != 0)
                        {
                            CourseFieldOfStudyMapping FOSMapping = new CourseFieldOfStudyMapping();
                            FOSMapping.CourseMasterID = course.CourseMasterID;
                            FOSMapping.FieldOfStudyMasterID = (int)item.FieldOfStudy.Id;
                            FOSMapping.FOSCredit = item.FieldOfStudyCredit;
                            FOSService.Add(FOSMapping);
                        }
                    }
                }
            });
        }
        private async Task SaveUpdateSGSLSNFormGroups(Course course)
        {
            await Task.Run(() =>
            {
                CourseSGSLSNMappingService SGSLSNService = new CourseSGSLSNMappingService();
                if (course.SGSLSNFormGroups != null && course.SGSLSNFormGroups.Any())
                {
                    SGSLSNService.Remove(course.CourseMasterID);
                    foreach (var item in course.SGSLSNFormGroups)
                    {
                        if (item != null && item.ServiceGroup !=null && item.ServiceGroup?.Id != 0)
                        {
                            CourseSGSLSNMapping SGSLSNMapping = new CourseSGSLSNMapping();
                            SGSLSNMapping.CourseMasterID = course.CourseMasterID;
                            SGSLSNMapping.ServiceGroupID = (int)item.ServiceGroup.Id;
                            SGSLSNMapping.ServiceLineID = (int)item.ServiceLine.Id;
                            SGSLSNMapping.ServiceNetworkID = (int)item.ServiceNetwork.Id;
                            SGSLSNService.Add(SGSLSNMapping);
                        }
                    }
                }
            });
        }
        private async Task SaveUpdateEquivalentCourseIDService(Course course)
        {
            await Task.Run(() =>
            {
                EquivalentCourseIDMappingService equivalentCourseIDService = new EquivalentCourseIDMappingService();
                if (course.EquivalentCourseIDFormGroup != null && course.EquivalentCourseIDFormGroup.Any())
                {
                    equivalentCourseIDService.Remove(course.CourseMasterID);
                    foreach (var item in course.EquivalentCourseIDFormGroup)
                    {
                        if (item!= null && item.EquivalentCourseID != null && item.EquivalentCourseID != "")
                        {
                            EquivalentCourseIDMapping equivalentCourseID = new EquivalentCourseIDMapping();
                            equivalentCourseID.CourseMasterID = course.CourseMasterID;
                            equivalentCourseID.EquivalentCourseID = item.EquivalentCourseID;
                            equivalentCourseIDService.Add(equivalentCourseID);
                        }
                    }
                }
            });
        }
        private async Task SaveUpdatePrerequisiteCourseIDService(Course course)
        {
            await Task.Run(() =>
            {
                PrerequisiteCourseIDMappingService prerequisiteCourseIDService = new PrerequisiteCourseIDMappingService();
                if (course.PrerequisiteCourseIDFormGroup != null && course.PrerequisiteCourseIDFormGroup.Any())
                {
                    prerequisiteCourseIDService.Remove(course.CourseMasterID);
                    foreach (var item in course.PrerequisiteCourseIDFormGroup)
                    {
                        if (item != null && item.PrerequisiteCourseID != null && item.PrerequisiteCourseID != "")
                        {
                            PrerequisiteCourseIDMapping prerequisiteCourseID = new PrerequisiteCourseIDMapping();
                            prerequisiteCourseID.CourseMasterID = course.CourseMasterID;
                            prerequisiteCourseID.PrerequisiteCourseID = item.PrerequisiteCourseID;
                            prerequisiteCourseIDService.Add(prerequisiteCourseID);
                        }
                    }
                }
            });
        }
        private async Task SaveUpdateaudienceTypeService(Course course)
        {
            await Task.Run(() =>
            {
                AudienceTypeMappingService audienceTypeService = new AudienceTypeMappingService();
                if (course.AudienceTypeFormGroup != null && course.AudienceTypeFormGroup.Any())
                {
                    audienceTypeService.Remove(course.CourseMasterID);
                    foreach (var item in course.AudienceTypeFormGroup)
                    {
                        if (item != null && item.AudienceType != null && item.AudienceType != "")
                        {
                            AudienceTypeMapping audienceType = new AudienceTypeMapping();
                            audienceType.CourseMasterID = course.CourseMasterID;
                            audienceType.AudienceType = item.AudienceType;
                            audienceTypeService.Add(audienceType);
                        }
                    }
                }
            });
        }
        private async Task SaveUpdateCourseFunctionService(Course course)
        {
            await Task.Run(() =>
            {
                CourseFunctionMasterMappingService courseFunctionService = new CourseFunctionMasterMappingService();
                if (course.FunctionMasterIDs != null && course.FunctionMasterIDs.Any())
                {
                    courseFunctionService.Remove(course.CourseMasterID);
                    foreach (var item in course.FunctionMasterIDs)
                    {
                        if (item != null && item?.Id != 0)
                        {
                            CourseFunctionMapping functionMapping = new CourseFunctionMapping();
                            functionMapping.CourseMasterID = course.CourseMasterID;
                            functionMapping.FunctionMasterID = (int)item.Id;
                            courseFunctionService.Add(functionMapping);
                        }
                    }
                }
            });
        }
        private async Task SaveUpdateCourseOwnerService(Course course)
        {
            await Task.Run(() =>
            {
                FOCUSCourseOwnerMappingService courseOwnerService = new FOCUSCourseOwnerMappingService();
                if (course.FOCUSCourseOwnerFormGroup != null && course.FOCUSCourseOwnerFormGroup.Any())
                {
                    courseOwnerService.Remove(course.CourseMasterID);
                    foreach (var item in course.FOCUSCourseOwnerFormGroup)
                    {
                        if (item !=null && item?.Id != 0)
                        {
                            FOCUSCourseOwnerMapping courseOwner = new FOCUSCourseOwnerMapping();
                            courseOwner.CourseMasterID = course.CourseMasterID;
                            courseOwner.FOCUSCourseOwnerId = (int)item.Id;
                            courseOwnerService.Add(courseOwner);
                        }
                    }
                }
            });
        }

        public APIResponse<string> DeleteCourse(int CourseMasterID)
        {
            try
            {
                CourseDataService service = new CourseDataService();
                service.Remove(CourseMasterID);
                return SuccessReponse("Success");
            }
            catch (Exception ex)
            {
                var error = LogError(ex);
                return Erroresponse<string>(error);
            }
        }
    }
}
