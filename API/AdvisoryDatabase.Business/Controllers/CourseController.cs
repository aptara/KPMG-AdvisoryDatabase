using AdvisoryDatabase.Business.Service;
using AdvisoryDatabase.Framework.Entities;
using AdvisoryDatabase.Framework.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void SaveUpdateSkillMasterIDs(Course course)
        {
            CourseSkillMappingService SkillService = new CourseSkillMappingService();
            if (course.SkillMasterIDs != null && course.SkillMasterIDs.Any())
            {
                SkillService.Remove(course.CourseMasterID);
                foreach (var item in course.SkillMasterIDs)
                {
                    if (item.Id != 0)
                    {
                        CourseSkillMapping courseSkillMapping = new CourseSkillMapping();
                        courseSkillMapping.CourseMasterID = course.CourseMasterID;
                        courseSkillMapping.SkillMasterID = (int)item.Id;
                        SkillService.Add(courseSkillMapping);
                    }
                }
            }
        }
        private void SaveUpdateIndustries(Course course)
        {
            CourseIndustryMappingService IndustryService = new CourseIndustryMappingService();
            if (course.Industries != null && course.Industries.Any())
            {
                IndustryService.Remove(course.CourseMasterID);
                foreach (var item in course.Industries)
                {
                    if (item.Id != 0)
                    {
                        CourseIndustryMapping courseIndustryMapping = new CourseIndustryMapping();
                        courseIndustryMapping.CourseMasterID = course.CourseMasterID;
                        courseIndustryMapping.IndustryID = (int)item.Id;
                        IndustryService.Add(courseIndustryMapping);
                    }
                }
            }
        }
        private void SaveUpdateAudienceLevels(Course course)
        {
            AudienceLevelMappingService audienceLevelService = new AudienceLevelMappingService();
            if (course.AudienceLevels != null && course.AudienceLevels.Any())
            {
                audienceLevelService.Remove(course.CourseMasterID);
                foreach (var item in course.AudienceLevels)
                {
                    if (item.Id != 0)
                    {
                        AudienceLevelMapping audienceLevelMapping = new AudienceLevelMapping();
                        audienceLevelMapping.CourseMasterID = course.CourseMasterID;
                        audienceLevelMapping.AudienceLevelId = (int)item.Id;
                        audienceLevelService.Add(audienceLevelMapping);
                    }
                }
            }
        }
        private void SaveUpdateFOSService(Course course)
        {
            CourseFieldOfStudyMappingService FOSService = new CourseFieldOfStudyMappingService();
            if (course.FieldOfStudyFormGroup != null && course.FieldOfStudyFormGroup.Any())
            {
                FOSService.Remove(course.CourseMasterID);
                foreach (var item in course.FieldOfStudyFormGroup)
                {
                    if (item.FieldOfStudy.Id != 0)
                    {
                        CourseFieldOfStudyMapping FOSMapping = new CourseFieldOfStudyMapping();
                        FOSMapping.CourseMasterID = course.CourseMasterID;
                        FOSMapping.FieldOfStudyMasterID = (int)item.FieldOfStudy.Id;
                        FOSMapping.FOSCredit = item.FieldOfStudyCredit;
                        FOSService.Add(FOSMapping);
                    }
                }
            }
        }
        private void SaveUpdateSGSLSNFormGroups(Course course)
        {
            CourseSGSLSNMappingService SGSLSNService = new CourseSGSLSNMappingService();
            if (course.SGSLSNFormGroups != null && course.SGSLSNFormGroups.Any())
            {
                SGSLSNService.Remove(course.CourseMasterID);
                foreach (var item in course.SGSLSNFormGroups)
                {
                    if (item.ServiceGroup.Id != 0)
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
        }
        private void SaveUpdateEquivalentCourseIDService(Course course)
        {
            EquivalentCourseIDMappingService equivalentCourseIDService = new EquivalentCourseIDMappingService();
            if (course.EquivalentCourseIDFormGroup != null && course.EquivalentCourseIDFormGroup.Any())
            {
                equivalentCourseIDService.Remove(course.CourseMasterID);
                foreach (var item in course.EquivalentCourseIDFormGroup)
                {
                    if (item.EquivalentCourseID != null && item.EquivalentCourseID != "")
                    {
                        EquivalentCourseIDMapping equivalentCourseID = new EquivalentCourseIDMapping();
                        equivalentCourseID.CourseMasterID = course.CourseMasterID;
                        equivalentCourseID.EquivalentCourseID = item.EquivalentCourseID;
                        equivalentCourseIDService.Add(equivalentCourseID);
                    }
                }
            }
        }
        private void SaveUpdatePrerequisiteCourseIDService(Course course)
        {
            PrerequisiteCourseIDMappingService prerequisiteCourseIDService = new PrerequisiteCourseIDMappingService();
            if (course.PrerequisiteCourseIDFormGroup != null && course.PrerequisiteCourseIDFormGroup.Any())
            {
                prerequisiteCourseIDService.Remove(course.CourseMasterID);
                foreach (var item in course.PrerequisiteCourseIDFormGroup)
                {
                    if (item.PrerequisiteCourseID != null && item.PrerequisiteCourseID != "")
                    {
                        PrerequisiteCourseIDMapping prerequisiteCourseID = new PrerequisiteCourseIDMapping();
                        prerequisiteCourseID.CourseMasterID = course.CourseMasterID;
                        prerequisiteCourseID.PrerequisiteCourseID = item.PrerequisiteCourseID;
                        prerequisiteCourseIDService.Add(prerequisiteCourseID);
                    }
                }
            }
        }
        private void SaveUpdateaudienceTypeService(Course course)
        {
            AudienceTypeMappingService audienceTypeService = new AudienceTypeMappingService();

            if (course.AudienceTypeFormGroup != null && course.AudienceTypeFormGroup.Any())
            {
                audienceTypeService.Remove(course.CourseMasterID);
                foreach (var item in course.AudienceTypeFormGroup)
                {
                    if (item.AudienceType != null && item.AudienceType != "")
                    {
                        AudienceTypeMapping audienceType = new AudienceTypeMapping();
                        audienceType.CourseMasterID = course.CourseMasterID;
                        audienceType.AudienceType = item.AudienceType;
                        audienceTypeService.Add(audienceType);
                    }
                }
            }
        }
        private void SaveUpdateCourseFunctionService(Course course)
        {
            CourseFunctionMasterMappingService courseFunctionService = new CourseFunctionMasterMappingService();

            if (course.FunctionMasterIDs != null && course.FunctionMasterIDs.Any())
            {
                courseFunctionService.Remove(course.CourseMasterID);
                foreach (var item in course.FunctionMasterIDs)
                {
                    if (item?.Id != 0)
                    {
                        CourseFunctionMapping functionMapping = new CourseFunctionMapping();
                        functionMapping.CourseMasterID = course.CourseMasterID;
                        functionMapping.FunctionMasterID = (int)item.Id;
                        courseFunctionService.Add(functionMapping);
                    }
                }
            }
        }
        private void SaveUpdateCourseOwnerService(Course course)
        {
            FOCUSCourseOwnerMappingService courseOwnerService = new FOCUSCourseOwnerMappingService();

            if (course.FOCUSCourseOwnerFormGroup != null && course.FOCUSCourseOwnerFormGroup.Any())
            {
                courseOwnerService.Remove(course.CourseMasterID);
                foreach (var item in course.FOCUSCourseOwnerFormGroup)
                {
                    if (item?.Id != 0)
                    {
                        FOCUSCourseOwnerMapping courseOwner = new FOCUSCourseOwnerMapping();
                        courseOwner.CourseMasterID = course.CourseMasterID;
                        courseOwner.FOCUSCourseOwnerId = (int)item.Id;
                        courseOwnerService.Add(courseOwner);
                    }
                }
            }
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
